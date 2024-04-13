using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelector : MonoBehaviour
{
    public static string[] StageList { get; set; } = { "Request_Tubo" };

    [SerializeField] List<string> stages;

    public void AddStage(string stageName)
    {
        stages.Add(stageName);
    }

    private void OnDestroy()
    {
        StageList = stages.ToArray();
    }
}
