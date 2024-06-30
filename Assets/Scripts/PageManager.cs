using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public int pageNum { get; private set; } = -1;
    public string pageName = "";

    static Canvas current;
    static SearchBar searchBar;
    static TMP_Dropdown history;
    Canvas canvas;
    TextMeshProUGUI tmp;
    Scrollbar scrollbar;

    // Start is called before the first frame update
    void Start()
    {
        if (searchBar == null)
        {
            searchBar = transform.parent.gameObject.GetComponent<SearchBar>();
        }

        if (history == null)
        {
            history = searchBar.gameObject.transform.Find("History").gameObject.GetComponent<TMP_Dropdown>();
        }

        searchBar.AddPage(this);
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

        Transform description = transform.Find("Scroll View/Viewport/Content/description");
        if (description != null)
        {
            tmp = description.gameObject.GetComponent<TextMeshProUGUI>();
        }

        Transform barTrans = transform.Find("Scroll View/Scrollbar Vertical");
        if (barTrans != null)
        {
            scrollbar = barTrans.gameObject.GetComponent<Scrollbar>();
        }

        if (pageName == "Home")
        {
            AddHistory();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Display()
    {
        history.value = pageNum;
    }

    public void Swap()
    {
        if (current != null)
        {
            current.enabled = false;
        }
        canvas.enabled = true;
        current = canvas;

        if (scrollbar != null)
        {
            scrollbar.value = 1.0f;
        }
    }

    public void AddHistory()
    {
        history.options.Add(new TMP_Dropdown.OptionData(pageName));
        pageNum = history.options.Count - 1;
        history.value = pageNum;
        history.RefreshShownValue();
        Swap();
    }

    public void LinkCheck()
    {
        if (tmp == null)
        {
            return;
        }

        Vector2 pos = Input.mousePosition;
        int link = TMP_TextUtilities.FindIntersectingLink(tmp, pos, null);

        if (link != -1)
        {
            string text = tmp.textInfo.linkInfo[link].GetLinkText();
            if (searchBar.Search(text)) return;

            string style = tmp.textInfo.linkInfo[link].GetLinkID();
            if (searchBar.Search(style)) return;
        }
    }
}
