using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLoader : MonoBehaviour
{
    public static NodeInfo Stage;
    public static int Score = 0;

    [SerializeField] TextMeshProUGUI stageLabel;
    [SerializeField] TextMeshProUGUI scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        stageLabel.text = Stage.stage.ToString();
        scoreLabel.text = $"{Score} / {StageSelector.RequestList.Length}";

        if (Stage.stage == StageBit.Day1_1)
        {
            if (Score > Stage.border)
            {
                StageSelector.ClearFlagTable |= StageBit.Day1_1;
            }
        }

        if (Stage.stage == StageBit.Day2_1)
        {
            if (Score > Stage.border)
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
