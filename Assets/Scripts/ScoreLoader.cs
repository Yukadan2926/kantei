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

        if (Stage.Equals("Day1"))
        {
            StageSelector.StageFlag[0] = 2;
            StageSelector.StageFlag[1] = 1;
        }

        if (Stage.Equals("Day2"))
        {
            StageSelector.StageFlag[1] = 2;

            if (Score > 0)
            {
                StageSelector.StageFlag[2] = 1;
            }
            else
            {
                StageSelector.StageFlag[3] = 1;
            }
        }

        if (Stage.Equals("Day3-1"))
        {
            StageSelector.StageFlag[2] = 2;
        }

        if (Stage.Equals("Day3-2"))
        {
            StageSelector.StageFlag[3] = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
