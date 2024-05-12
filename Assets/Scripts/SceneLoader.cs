using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
            additiveScenes.Add($"Request_{stageManager.requests[0].SceneName}");
            stageManager.AddOnClickCallack();
        }

        foreach (string str in additiveScenes)
        {
            SceneManager.LoadScene(str, LoadSceneMode.Additive);
        }

        fader = GetComponent<Fader>();
    }

    public void ProceedStage(string result)
    {
        RequestParam[] requests = stageManager.requests;
        int index = stageManager.index;
        SceneManager.UnloadSceneAsync($"Request_{requests[index].SceneName}");
        stageManager.index = ++index;

        if (index < requests.Length)
        {
            SceneManager.LoadScene(additiveScenes[0], LoadSceneMode.Additive);
            SceneManager.LoadScene($"Request_{requests[index].SceneName}", LoadSceneMode.Additive);
            stageManager.AddOnClickCallack();
        }
        else
        {
            SceneManager.LoadScene(result);
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
        SceneManager.UnloadSceneAsync("SearchScreen");
        StartCoroutine(transition(result, delaySecond, true));
    }

    public void TransScene(string scene)
    {
        StartCoroutine(transition(scene, delaySecond, false));
    }

    IEnumerator transition(string scene, float delay, bool stage)
    {
        fader.Fade(delaySecond);

        yield return new WaitForSeconds(delay);

        if (stage)
        {
            ProceedStage(scene);
        }
        else
        {
            LoadScene(scene);
        }

        fader.Fade(delay);
    }
}
