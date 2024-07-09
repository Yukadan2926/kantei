using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SearchBar : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Dropdown history;
    [SerializeField] GameObject notFound;

    Dictionary<string, PageManager> pageDict = new Dictionary<string, PageManager>();

    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddPage(PageManager page)
    {
        pageDict.Add(page.pageName, page);
    }

    private PageManager MatchWord(string word)
    {
        if (pageDict.ContainsKey(word))
        {
            return pageDict[word];
        }

        return null;
    }

    public void Jump(PageManager page)
    {
        if (page.pageNum > -1)
        {
            page.Display();
        }
        else
        {
            page.AddHistory();
        }
    }

    public void Search()
    {
        PageManager page = MatchWord(inputField.text);
        if (page != null)
        {
            Jump(page);
            inputField.text = "";
            return;
        }

        if (inputField.text != "")
        {
            Instantiate(notFound, transform);
        }
    }

    public bool Search(string word)
    {
        PageManager page = MatchWord(word);
        if (page != null)
        {
            Jump(page);
            return true;
        }

        return false;
    }

    public void LoadHistory()
    {
        foreach(PageManager page in pageDict.Values)
        {
            if (page.pageNum == history.value)
            {
                page.Swap();
                return;
            }
        }
    }
}
