using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLoader : MonoBehaviour
{
    //public static NodeInfo Stage;
    public static int Score;

    static StageBit Stage;
    static int Border;

    [SerializeField] TextMeshProUGUI stageLabel;
    [SerializeField] TextMeshProUGUI scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        stageLabel.text = Stage.ToString();
        scoreLabel.text = $"{Score} / {StageSelector.RequestList.Length}";

        if (Score >= Border)
        {
            StageSelector.ClearFlagTable |= Stage;
        }
    }

    public static void DecideStage(StageBit stage, int border)
    {
        Stage = stage;
        Border = border;
    }
}
