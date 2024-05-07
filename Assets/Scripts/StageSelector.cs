using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StageSelector : MonoBehaviour
{
    public static int[] StageFlag { get; set; } = { 1, 0, 0, 0 };

    public static string[] RequestList { get; set; } = { "Tubo" };

    public enum StageNum
    {
        Day1_1,
        Day2_1,
        Day3_1,
        Day3_2,
    }

    [SerializeField] List<Image> buttonList;
    [SerializeField] List<Canvas> canvasList;
    [SerializeField] List<TextMeshProUGUI> textList;

    List<string> requests;

    private void Start()
    {
        requests = new List<string>();


        int index = -1;
        foreach (var button in buttonList)
        {
            index++;
            button.enabled = StageFlag[index] >= 1;
        }

        canvasList[0].enabled = StageFlag[0] >= 1;
        canvasList[1].enabled = StageFlag[1] >= 1;
        canvasList[2].enabled = StageFlag[2] >= 1 || StageFlag[3] >= 1;

        textList[0].enabled = StageFlag[0] >= 2;
        textList[1].enabled = StageFlag[1] >= 2;
        textList[2].enabled = StageFlag[1] >= 2;

        if (textList[0].enabled)
        {
            textList[0].text = StageFlag[1] >= 1 ? "o" : "x";
        }

        if (textList[1].enabled)
        {
            textList[1].text = StageFlag[2] >= 1 ? "o" : "x";
            textList[2].text = StageFlag[3] >= 1 ? "o" : "x";
        }
    }

    public void Select(string str)
    {
        ScoreLoader.Stage = str;
    }

    public void AddStage(RequestParam request)
    {
        requests.Add(request.SceneName);
    }

    private void OnDestroy()
    {
        RequestList = requests.ToArray();
    }
}
