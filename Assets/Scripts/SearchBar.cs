using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchBar : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject notFound;

    [SerializeField] TMP_Dropdown historyDropDown;
    [SerializeField] TMP_Dropdown suggestionDropDown;

    [SerializeField] List<GameObject> tabs = new List<GameObject>();

    List<Toggle> toggles = new List<Toggle>();
    List<tabInfo> infos = new List<tabInfo>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject tab in tabs)
        {
            toggles.Add(tab.GetComponent<Toggle>());
            infos.Add(tab.GetComponent<tabInfo>());
        }

        AddHistory(infos[0]);
    }

    public void OnIFEndEdit()
    {
        string str = inputField.text;
        ChangeTab(str);
    }

    private void ChangeTab(string str)
    {
        int index = MatchAll(str);
        if (index >= 0)
        {
            toggles[index].isOn = true;

            if (infos[index].num < 0)
            {
                AddHistory(infos[index]);
            }
            else
            {
                historyDropDown.value = infos[index].num;
            }

            inputField.text = "";
        }
        else if (str != "")
        {
            GameObject child = Instantiate(notFound, transform);
        }
    }

    public void UpdateSuggestion()
    {
        suggestionDropDown.Hide();
        suggestionDropDown.ClearOptions();

        string str = inputField.text;
        List<string> suggestions = MatchBeginList(str);
        if (suggestions.Count > 0)
        {
            foreach(string text in suggestions)
            {
                suggestionDropDown.options.Add(new TMP_Dropdown.OptionData(text));
            }
        }

        suggestionDropDown.Show();
    }

    public void OnSuggestionSelected()
    {
        string str = suggestionDropDown.options[suggestionDropDown.value].text;
        ChangeTab(str);
    }

    public void JumpHistory()
    {
        for (int i = 0; i < infos.Count; i++)
        {
            if (historyDropDown.value == infos[i].num)
            {
                toggles[i].isOn = true;
            }
        }
    }

    public void ReturnHomeTab()
    {
        toggles[0].isOn = true;
        historyDropDown.value = 0;
    }

    public void AddHistory(tabInfo info)
    {
        historyDropDown.options.Add(new TMP_Dropdown.OptionData(info.tabName));
        historyDropDown.value = historyDropDown.options.Count - 1;
        historyDropDown.RefreshShownValue();
        info.num = historyDropDown.options.Count - 1;
    }

    public int MatchAll(string str)
    {
        for (int i = 0; i < infos.Count; i++)
        {
            if (infos[i].tabName.Equals(str))
            {
                return i;
            }
        }

        return -1;
    }

    private List<string> MatchBeginList(string str)
    {
        List<string> list = new List<string>();
        if (str == "")
        {
            return list;
        }

        foreach (tabInfo info in infos)
        {
            if (info.tabName.StartsWith(str))
            {
                list.Add(info.tabName);
            }
        }

        return list;
    }

    public void LinkCheck(TextMeshProUGUI tmp)
    {
        Vector2 pos = Input.mousePosition;
        int link = TMP_TextUtilities.FindIntersectingLink(tmp, pos, null);

        if (link != -1)
        {
            string text = tmp.textInfo.linkInfo[link].GetLinkText();
            int index = MatchAll(text);
            if (index >= 0)
            {
                toggles[index].isOn = true;

                if (infos[index].num < 0)
                {
                    AddHistory(infos[index]);
                }
                else
                {
                    historyDropDown.value = infos[index].num;
                }
            }
        }
    }
}
