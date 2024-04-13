using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePaper : MonoBehaviour
{
    Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void OnClick()
    {
        toggle.isOn = !toggle.isOn;
    }
}
