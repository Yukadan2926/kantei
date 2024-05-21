using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkPanel : MonoBehaviour
{
    static bool s_hide = false;
    Canvas canvas;

    [SerializeField] List<Toggle> LinesList;
    int index;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        index = 0;
    }

    void Update()
    {
        canvas.enabled = !s_hide;
    }

    public static void Hide(bool hide)
    {
        s_hide = hide;
    }

    public void OnClick()
    {
        index++;
        if (index < LinesList.Count)
        {
            LinesList[index].isOn = true;
        }
    }
}
