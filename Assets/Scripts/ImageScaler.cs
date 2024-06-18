using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ImageScaler : MonoBehaviour
{
    static RectTransform panel;
    RectTransform image;
    float aspect;

    // Start is called before the first frame update
    void Start()
    {
        if (panel == null)
        {
            panel = GameObject.Find("SearchPanel").transform as RectTransform;
        }

        image = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        aspect = image.rect.height / image.rect.width;

        image.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, panel.rect.width - 20);
        image.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, image.rect.width * aspect);
    }
}
