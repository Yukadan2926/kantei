using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public List<string> additiveScenes = new List<string>();

    StageManager stageManager;
    Fader fader;

    // Start is called before the first frame update
    void Start()
    {
        stageManager = GetComponent<StageManager>();
        if (stageManager != null )
        {
            additiveScenes.Add(stageManager.stages[0]);
        }

        foreach (string str in additiveScenes)
        {
            SceneManager.LoadScene(str, LoadSceneMode.Additive);
        }

        fader = GetComponent<Fader>();
    }

    public void ProceedStage(string str)
    {
        var stages = stageManager.stages;
        var index = stageManager.index;
        SceneManager.UnloadSceneAsync(stages[index]);
        stageManager.index = ++index;

        if (index < stages.Length)
        {
            SceneManager.LoadScene(stages[index], LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(str);
        }
    }

    public float delaySecond
    {
        get;
        set;
    }

    public void LoadScene(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void TransStage(string result)
    {
        StartCoroutine(transition(result, delaySecond, true));
    }

    public void TransScene(string sceneName)
    {
        StartCoroutine(transition(sceneName, delaySecond, false));
    }

    IEnumerator transition(string str, float delay, bool stage)
    {
        fader.Fade(delaySecond);

        yield return new WaitForSeconds(delay);

        if (stage)
        {
            ProceedStage(str);
        }
        else
        {
            LoadScene(str);
        }

        fader.Fade(delay);
    }
}
