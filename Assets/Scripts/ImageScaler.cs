using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ImageScaler : MonoBehaviour
{
    static RectTransform panel;
    RectTransform image;
    Rect startRect;

    // Start is called before the first frame update
    void Start()
    {
        if (panel == null)
        {
            panel = GameObject.Find("SearchPanel").transform as RectTransform;
        }

        image = GetComponent<RectTransform>();
        startRect = image.rect;
    }

    // Update is called once per frame
    void Update()
    {
        float f = (panel.rect.width - 20) / startRect.width;
        Vector3 scl = new Vector3(f, f, 1.0f);
        image.localScale = scl;
    }
}
