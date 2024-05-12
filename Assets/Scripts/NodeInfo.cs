using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeInfo : MonoBehaviour
{
    [SerializeField] int date;
    [SerializeField] StageBit stage;

    [SerializeField] List<StageBit> AppearCondition;
    [SerializeField] List<StageBit> ClearCondition;
    [SerializeField] List<ActionBit> ActionCondition;
    StageBit aprc;
    StageBit clrc;
    ActionBit actc;

    [SerializeField] List<RequestParam> requests;

    Image image;

    private void Start()
    {
        aprc = StageBit.None;
        clrc = StageBit.None;
        actc = ActionBit.None;
        foreach (var condition in AppearCondition)
        {
            aprc |= condition;
        }
        foreach (var condition in ClearCondition)
        {
            clrc |= condition;
        }
        foreach (var condition in ActionCondition)
        {
            actc |= condition;
        }

        image = GetComponent<Image>();

        if (StageSelector.AppearFlagTable.HasFlag(aprc) &&
            StageSelector.ClearFlagTable.HasFlag(clrc) &&
            StageSelector.ActionFlagTable.HasFlag(actc))
        {
            StageSelector.AppearFlagTable |= stage;
        }

        image.enabled = StageSelector.AppearFlagTable.HasFlag(stage);
    }

    public void OnClick()
    {
        ScoreLoader.Stage = stage;
        StageSelector.RequestList = requests.ToArray();
    }
}
