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

    public void Search()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            if (pages[i].pageName == inputField.text)
            {
                if (pages[i].pageNum > -1)
                {
                    pages[i].Display();
                }
                else
                {
                    pages[i].AddHistory();
                }

                inputField.text = "";
                return;
            }
        }

        Instantiate(notFound);
    }

    public void LoadHistory()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            if (pages[i].pageNum == history.value)
            {
                pages[i].Display();
                return;
            }
        }
    }

    //public void LinkCheck(TextMeshProUGUI tmp)
    //{
    //    Vector2 pos = Input.mousePosition;
    //    int link = TMP_TextUtilities.FindIntersectingLink(tmp, pos, Camera.main);

    //    if (link != -1)
    //    {
    //        string text = tmp.textInfo.linkInfo[link].GetLinkText();
    //        int index = MatchAll(text);
    //        if (index >= 0)
    //        {
    //            toggles[index].isOn = true;

    //            if (infos[index].num < 0)
    //            {
    //                AddHistory(infos[index]);
    //            }
    //            else
    //            {
    //                historyDropDown.value = infos[index].num;
    //            }

    //            return;
    //        }

    //        string style = tmp.textInfo.linkInfo[link].GetLinkID();
    //        index = MatchAll(style);
    //        if (index >= 0)
    //        {
    //            toggles[index].isOn = true;

    //            if (infos[index].num < 0)
    //            {
    //                AddHistory(infos[index]);
    //            }
    //            else
    //            {
    //                historyDropDown.value = infos[index].num;
    //            }

    //            return;
    //        }
    //    }
    //}
}
