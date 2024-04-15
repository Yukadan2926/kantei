using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelector : MonoBehaviour
{
    public static string[] RequestList { get; set; } = { "Tubo" };

    [SerializeField] List<string> requests;

    public void AddStage(RequestParam request)
    {
        requests.Add(request.SceneName);
    }

    private void OnDestroy()
    {
        RequestList = requests.ToArray();
    }
}
