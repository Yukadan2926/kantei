using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCanHide : MonoBehaviour
{
    static bool s_hide = false;

    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        canvas.enabled = !s_hide;
    }

    public static void Hide(bool hide)
    {
        s_hide = hide;
    }
}
