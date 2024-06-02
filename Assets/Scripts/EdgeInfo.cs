using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EdgeInfo : MonoBehaviour
{
    public TextMeshProUGUI text;
    public NodeInfo after;

    private void Start()
    {
        GameObject.Find("StageSelector").GetComponent<StageSelector>().edgeList.Add(this);
    }
}
