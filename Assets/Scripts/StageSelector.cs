using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum StageBit
{
    None,
    Day1_1 = 0b_0001,
    Day2_1 = 0b_0010,
    Day3_1 = 0b_0100,
    Day3_2 = 0b_1000,
}

public class StageSelector : MonoBehaviour
{
    public static StageBit AppearFlagTable = StageBit.Day1_1;
    public static StageBit ClearFlagTable = StageBit.None;

    public static string[] RequestList { get; set; } = { "Tubo" };

    [SerializeField] List<Image> buttonList;
    [SerializeField] List<Canvas> canvasList;
    [SerializeField] List<TextMeshProUGUI> textList;

    List<string> requests;

    private void Start()
    {
        requests = new List<string>();

        canvasList[0].enabled = AppearFlagTable.HasFlag(StageBit.Day1_1);
        canvasList[1].enabled = AppearFlagTable.HasFlag(StageBit.Day2_1);
        canvasList[2].enabled = AppearFlagTable.HasFlag(StageBit.Day3_1) ||
                                AppearFlagTable.HasFlag(StageBit.Day3_2);

        int flagTable = (int)AppearFlagTable;
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].enabled = flagTable % 2 == 1;
            flagTable >>= 1;
        }

        textList[0].enabled = ClearFlagTable.HasFlag(StageBit.Day1_1);
        textList[1].enabled = ClearFlagTable.HasFlag(StageBit.Day2_1);
        textList[2].enabled = ClearFlagTable.HasFlag(StageBit.Day2_1);

        textList[0].text = AppearFlagTable.HasFlag(StageBit.Day2_1) ? "o" : "x";
        textList[1].text = AppearFlagTable.HasFlag(StageBit.Day3_1) ? "o" : "x";
        textList[2].text = AppearFlagTable.HasFlag(StageBit.Day3_2) ? "o" : "x";
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
