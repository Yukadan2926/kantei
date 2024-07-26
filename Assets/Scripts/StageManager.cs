using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    static int curReq = 0;

    [SerializeField] GameObject panelObj;

    SceneLoader sceneLoader;
    RequestParam[] requests;

    private void Start()
    {
        instance = this;

        sceneLoader = GetComponent<SceneLoader>();
        requests = StageSelector.RequestList;
        if (requests ==  null)
        {
            string sceneName = SceneManager.GetActiveScene().name.Substring(8);
            RequestParam param = Resources.Load($"Data_{sceneName}") as RequestParam;
            
            requests = new RequestParam[1];
            requests[0] = param;
        }
    }

    public void Judge(bool ans)
    {
        if (ans == requests[curReq].Answer)
        {
            ScoreLoader.Score += 1;
        }
    }

    public void Proceed()
    {
        curReq++;
        if (curReq < requests.Length)
        {
            sceneLoader.TransScene($"Request_{requests[curReq].SceneName}");
        }
        else
        {
            sceneLoader.TransScene("Result");
            curReq = 0;
        }
    }

    public void TalkEvent(int num)
    {
        GameObject inst = Instantiate(panelObj);
        TalkPanel talkPanel = inst.GetComponent<TalkPanel>();
        talkPanel.SetLines(requests[curReq], num);
    }
}
