using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScaler : MonoBehaviour
{
    RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float width = rt.rect.width;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            width += 10;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            width -= 10;
        }
        width = Mathf.Clamp(width, 600, 1800);

        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }
}
