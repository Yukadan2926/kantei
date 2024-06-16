using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchBar : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Dropdown history;
    [SerializeField] GameObject notFound;

    List<PageManager> pages = new List<PageManager>();

    // Start is called before the first frame update
    void Start()
    {
        //pages.Clear();
    }

    public void AddPage(PageManager page)
    {
        pages.Add(page);
    }

    private int MatchWord(string word)
    {
        for (int i = 0; i < pages.Count; i++)
        {
            if (pages[i].pageName == word)
            {
                return i;
            }
        }

        return -1;
    }

    public void Search()
    {
        int index = MatchWord(inputField.text);
        if (index > -1)
        {
            if (pages[index].pageNum > -1)
            {
                pages[index].Display();
            }
            else
            {
                pages[index].AddHistory();
            }
            inputField.text = "";
        }

        if (inputField.text != "")
        {
            Instantiate(notFound, transform);
        }
    }

    public bool Search(string word)
    {
        int index = MatchWord(word);
        if (index > -1)
        {
            if (pages[index].pageNum > -1)
            {
                pages[index].Display();
            }
            else
            {
                pages[index].AddHistory();
            }
            inputField.text = "";
            return true;
        }

        if (inputField.text != "")
        {
            Instantiate(notFound, transform);
        }
        return false;
    }

    public void LoadHistory()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            if (pages[i].pageNum == history.value)
            {
                pages[i].Swap();
                return;
            }
        }
    }
}
