using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeInfo : MonoBehaviour
{
    public int date;
    public StageBit stage;
    public int border;
    public Image image;

    public List<StageBit> AppearCondition;
    public List<StageBit> ClearCondition;
    public List<ActionBit> ActionCondition;
    public List<RequestParam> requests;

    private void Start()
    {
        GameObject.Find("StageSelector").GetComponent<StageSelector>().nodeList.Add(this);
    }

    public void OnClick()
    {
        ScoreLoader.DecideStage(stage, border);
        StageSelector.RequestList = requests.ToArray();
    }
}
