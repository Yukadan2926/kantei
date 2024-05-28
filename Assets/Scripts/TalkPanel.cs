using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkPanel : MonoBehaviour
{
    [SerializeField] Person person;
    [SerializeField] List<Toggle> LinesList;
    int index;

    private void Start()
    {
        index = 0;
    }

    public void OnClick()
    {
        index++;
        if (index < LinesList.Count)
        {
            LinesList[index].isOn = true;
        }
        else
        {
            StageManager.instance.Proceed();
        }
    }
}
