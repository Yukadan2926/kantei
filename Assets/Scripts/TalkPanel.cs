using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkPanel : MonoBehaviour
{
    TextMeshProUGUI text;
    List<string> lines;
    int curLine;
    bool end = false;

    BaseEvent manager;
    Canvas appraisePanel;

    private void Start()
    {
        text = transform.Find("Background/Line").gameObject.GetComponent<TextMeshProUGUI>();

        curLine = 0;
        text.text = lines[curLine];

        appraisePanel = GameObject.Find("appraisePanel").GetComponent<Canvas>();
        appraisePanel.enabled = false;
    }

    public void SetLines(RequestParam param, int num)
    {
        lines = param.events[num].lines;

        if (num <= 1)
        {
            end = true;
        }
    }

    public void OnClick()
    {
        curLine++;
        if (curLine < lines.Count)
        {
            text.text = lines[curLine];
        }
        else
        {
            if (!end)
            {

                appraisePanel.enabled = true;
            }
            else
            {
                StageManager.instance.Proceed();
            }

            Destroy(gameObject);
        }
    }
}
