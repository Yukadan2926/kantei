using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLoader : MonoBehaviour
{
    public static string Stage = "";
    public static int Score = 0;

    [SerializeField] TextMeshProUGUI stageLabel;
    [SerializeField] TextMeshProUGUI scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        stageLabel.text = Stage;
        scoreLabel.text = $"{Score} / {StageSelector.RequestList.Length}";

        if (Stage == "Day1")
        {
            if (Score > 0)
            {
                StageSelector.ClearFlagTable |= StageBit.Day1_1;
                StageSelector.AppearFlagTable |= StageBit.Day2_1;
            }
        }

        if (Stage == "Day2")
        {
            if (Score > 0)
            {
                StageSelector.ClearFlagTable |= StageBit.Day2_1;
                StageSelector.AppearFlagTable |= StageBit.Day3_1;
            }
            else
            {
                StageSelector.ClearFlagTable |= StageBit.Day2_1;
                StageSelector.AppearFlagTable |= StageBit.Day3_2;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
