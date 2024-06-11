using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public int pageNum { get; private set; } = -1;
    public string pageName = "";

    static GameObject panel;
    static TMP_Dropdown history;
    Canvas canvas;
    Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        if (panel == null)
        {
            panel = transform.parent.gameObject;
        }

        if (history == null)
        {
            history = panel.transform.Find("History").gameObject.GetComponent<TMP_Dropdown>();
        }

        panel.GetComponent<SearchBar>().AddPage(this);
        canvas = GetComponent<Canvas>();
        toggle = GetComponent<Toggle>();
        canvas.enabled = toggle.isOn;

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
        toggle.isOn = true;
    }

    public void AddHistory()
    {
        history.options.Add(new TMP_Dropdown.OptionData(pageName));
        history.value = history.options.Count - 1;
        history.RefreshShownValue();
        pageNum = history.options.Count - 1;
        Display();
    }
}
