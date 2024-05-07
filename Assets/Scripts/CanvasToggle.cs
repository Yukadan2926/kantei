using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasToggle : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        UpdateOnce();
    }

    public void OpenCanvas()
    {
        if (toggle.isOn)
        {
            canvas.enabled = true;
        }
    }

    public void UpdateOnce()
    {
        canvas.enabled = toggle.isOn;
    }
}
