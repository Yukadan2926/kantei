using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    static int current = 0;

    [SerializeField] Button realButton;
    [SerializeField] Button fakeButton;
    [SerializeField] Canvas realCanvas;
    [SerializeField] Canvas fakeCanvas;

    SceneLoader sceneLoader;
    RequestParam[] requests;

    private void Start()
    {
        instance = this;

        realCanvas.enabled = false;
        fakeCanvas.enabled = false;

        sceneLoader = GetComponent<SceneLoader>();
        requests = StageSelector.RequestList;
        if (requests ==  null)
        {
            requests = new RequestParam[0];
        }
    }

    public void AddScore()
    {
        ScoreLoader.Score += 1;
    }

    public void Proceed()
    {
        realCanvas.enabled = false;
        fakeCanvas.enabled = false;

        current++;
        if (current < requests.Length)
        {
            sceneLoader.TransScene($"Request_{requests[current].SceneName}");
        }
        else
        {
            sceneLoader.TransScene("Result");
            current = 0;
        }
    }
}
