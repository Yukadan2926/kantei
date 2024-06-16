using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Suggest : MonoBehaviour
{
    public TMP_InputField input;
    public GameObject suggestList;

    public PageParams pageParams;
    List<string> hits = new List<string>();

    RectTransform content;
    RectTransform itemTemp;
    List<GameObject> items = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        content = suggestList.transform.Find("Viewport/Content") as RectTransform;
        itemTemp = content.Find("Item") as RectTransform;
        itemTemp.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Display()
    {
        if (suggestList != null)
        {
            suggestList.SetActive(true);
        }
    }

    void Hide()
    {
        if (suggestList != null)
        {
            foreach (GameObject item in items)
            {
                Destroy(item);
            }
            items.Clear();
            suggestList.SetActive(false);
        }
    }

    public void Search()
    {
        if (input != null)
        {
            if (input.text.Length > 0)
            {
                Display();
                
                hits.Clear();
                int cnt = 0;
                foreach(PageParam page in pageParams.pages)
                {
                    if (page.title.StartsWith(input.text))
                    {
                        cnt++;
                        hits.Add(page.title);
                    }
                }

                float height = content.rect.height;
                RectTransform st = suggestList.transform as RectTransform;
                st.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height * cnt);

                for (int i = 0; i < hits.Count; i++)
                {
                    GameObject item = Instantiate(itemTemp.gameObject, content);
                    RectTransform labelTrans = item.transform.Find("Item Label") as RectTransform;
                    TextMeshProUGUI labelText = labelTrans.gameObject.GetComponent<TextMeshProUGUI>();
                    labelText.text = hits[i];
                    RectTransform ip = item.transform as RectTransform;
                    ip.anchoredPosition = new Vector2(0, height * -i);
                    item.SetActive(true);

                    items.Add(item);
                }
            }
            else
            {
                Hide();
            }
        }
    }
}
