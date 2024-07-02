using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum StageBit
{
    None,
    Day1_1 = 0b_0000_0001,
    Day2_1 = 0b_0000_0010,
    Day3_1 = 0b_0000_0100,
    Day4_1 = 0b_0000_1000,
    Day5_1 = 0b_0001_0000,
    DebugFlag = 0b_0001_1111,
}

public enum ActionBit
{
    None,
}

[DefaultExecutionOrder(1)]
public class StageSelector : MonoBehaviour
{
    public static StageBit AppearFlagTable = StageBit.DebugFlag;
    public static StageBit ClearFlagTable = StageBit.DebugFlag;
    public static ActionBit ActionFlagTable = ActionBit.None;

    public static RequestParam[] RequestList;

    public List<NodeInfo> nodeList;
    public List<EdgeInfo> edgeList;
    public List<TextMeshProUGUI> dateLabelList;

    private void Start()
    {
        ScoreLoader.Score = 0;

        foreach (var node in nodeList) node.image.enabled = false;
        foreach (var edge in edgeList) edge.text.enabled = false;
        foreach (var label in dateLabelList) label.enabled = false;

        foreach (NodeInfo node in nodeList)
        {
            StageBit aprc = StageBit.None;
            StageBit clrc = StageBit.None;
            ActionBit actc = ActionBit.None;
            foreach (var condition in node.AppearCondition)
            {
                aprc |= condition;
            }
            foreach (var condition in node.ClearCondition)
            {
                clrc |= condition;
            }
            foreach (var condition in node.ActionCondition)
            {
                actc |= condition;
            }

            if (AppearFlagTable.HasFlag(aprc) &&
                ClearFlagTable.HasFlag(clrc) &&
                ActionFlagTable.HasFlag(actc))
            {
                AppearFlagTable |= node.stage;
                node.image.enabled = true;
                dateLabelList[node.date - 1].enabled = true;

                foreach (EdgeInfo edge in edgeList)
                {
                    if (node.date == edge.after.date)
                    {
                        edge.text.enabled = true;
                        edge.text.text = AppearFlagTable.HasFlag(edge.after.stage) ? "o" : "x";
                    }
                }
            }
        }
    }

    public void Begin()
    {
        GetComponent<SceneLoader>().LoadScene($"Request_{RequestList[0].SceneName}");
    }
}
