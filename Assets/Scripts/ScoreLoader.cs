using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLoader : MonoBehaviour
{
    public static StageBit Stage = StageBit.None;
    public static int Score = 0;

    [SerializeField] TextMeshProUGUI stageLabel;
    [SerializeField] TextMeshProUGUI scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        stageLabel.text = Stage.ToString();
        scoreLabel.text = $"{Score} / {StageSelector.RequestList.Length}";

        if (Stage == StageBit.Day1_1)
        {
            if (Score > 0)
            {
                StageSelector.ClearFlagTable |= StageBit.Day1_1;
            }
        }

        if (Stage == StageBit.Day2_1)
        {
            if (Score > 0)
            {
                StageSelector.ClearFlagTable |= StageBit.Day2_1;
            }
            else
            {
                StageSelector.ActionFlagTable |= ActionBit.FailedDay2_1;
            }
        }
    }
}
