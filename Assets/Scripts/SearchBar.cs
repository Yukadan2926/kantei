using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchBar : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject dropdownObject;
    [SerializeField] GameObject notFound;
    [SerializeField] List<GameObject> tabs = new List<GameObject>();

    TMP_Dropdown dropdownComp;

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

        dropdownComp = dropdownObject.GetComponent<TMP_Dropdown>();
        AddHistory(infos[0]);
    }

    public void ReadInput()
    {
        string str = inputField.text;
        if (Jump(str))
        {
            inputField.text = "";
        }
        else if (str != "")
        {
            GameObject child = Instantiate(notFound, transform);
        }
    }

    public void ReadDropdown()
    {
        int cnt = -1;
        foreach (tabInfo info in infos)
        {
            cnt++;
            if (dropdownComp.value == info.num)
            {
                toggles[cnt].isOn = true;
            }
        }
    }

    public void ReturnHomeTab()
    {
        toggles[0].isOn = true;
        dropdownComp.value = 0;
    }

    public void AddHistory(tabInfo info)
    {
        dropdownComp.options.Add(new TMP_Dropdown.OptionData(info.tabName));
        dropdownComp.value = dropdownComp.options.Count - 1;
        dropdownComp.RefreshShownValue();
        info.num = dropdownComp.options.Count - 1;
    }

    public bool Jump(string str)
    {
        int cnt = -1;
        foreach (tabInfo info in infos)
        {
            cnt++;
            if (str.Equals(info.tabName))
            {
                toggles[cnt].isOn = true;

                if (info.num < 0)
                {
                    AddHistory(info);
                }
                else
                {
                    dropdownComp.value = info.num;
                }

                return true;
            }
        }

        return false;
    }

    public void LinkCheck(TextMeshProUGUI tmp)
    {
        Vector2 pos = Input.mousePosition;
        int index = TMP_TextUtilities.FindIntersectingLink(tmp, pos, null);

        if (index != -1)
        {
            string text = tmp.textInfo.linkInfo[index].GetLinkText();
            Jump(text);
        }
    }
}
