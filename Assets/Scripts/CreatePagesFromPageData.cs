using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
public class CreatePagesFromPageData : Object
{
    [MenuItem("SearchScreen/CreatePages")]
    static void CreatePages()
    {
        GameObject panel = GameObject.Find("SearchPanel");
        if (panel == null)
        {
            Debug.Log("SearchPanel Not Find");
            return;
        }
        Transform temp = panel.transform.Find("TemplatePage");
        if (temp == null)
        {
            Debug.Log("TemplatePage Not Find");
            return;
        }
        PageParams pages = Resources.Load("PageData") as PageParams;
        if (pages == null)
        {
            Debug.Log("PageData Not Find");
            return;
        }

        foreach (PageParam page in pages.pages)
        {
            GameObject instance;
            Transform child = panel.transform.Find($"p_{page.objectName}");
            if (child == null)
            {
                instance = Instantiate(temp.gameObject, panel.transform);
                instance.name = $"p_{page.objectName}";
            }
            else
            {
                instance = child.gameObject;
            }

            instance.GetComponent<PageManager>().pageName = page.title;

            Transform titleTrans = instance.transform.Find("Scroll View/Viewport/Content/title");
            Transform descTrans = instance.transform.Find("Scroll View/Viewport/Content/description");
            if (titleTrans == null || descTrans == null)
            {
                continue;
            }

            TextMeshProUGUI titleText = titleTrans.gameObject.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI descText = descTrans.gameObject.GetComponent<TextMeshProUGUI>();
            titleText.text = page.title;
            descText.text = page.description;

            instance.SetActive(true);
        }
    }
}
#endif
