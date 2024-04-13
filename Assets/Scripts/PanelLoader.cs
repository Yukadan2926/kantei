using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLoader : MonoBehaviour
{
    public void LoadPanel(GameObject panel)
    {
        Canvas canvas = panel.GetComponent<Canvas>();
        canvas.enabled = true;
    }

    public void UnloadPanel(GameObject panel)
    {
        Canvas canvas = panel.GetComponent<Canvas>();
        canvas.enabled = false;
    }
}
