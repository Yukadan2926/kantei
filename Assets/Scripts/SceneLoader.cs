using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
            additiveScenes.Add($"Request_{stageManager.requests[0]}");
            stageManager.AddOnClickCallack();
        }

        foreach (string str in additiveScenes)
        {
            SceneManager.LoadScene(str, LoadSceneMode.Additive);
        }

        fader = GetComponent<Fader>();
    }

    public void ProceedStage(SceneAsset result)
    {
        var requests = stageManager.requests;
        var index = stageManager.index;
        SceneManager.UnloadSceneAsync($"Request_{requests[index]}");
        stageManager.index = ++index;

        if (index < requests.Length)
        {
            SceneManager.LoadScene(additiveScenes[0], LoadSceneMode.Additive);
            SceneManager.LoadScene($"Request_{requests[index]}", LoadSceneMode.Additive);
            stageManager.AddOnClickCallack();
        }
        else
        {
            SceneManager.LoadScene(result.name);
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

    public void LoadScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public void TransStage(SceneAsset result)
    {
        SceneManager.UnloadSceneAsync("SearchScreen");
        StartCoroutine(transition(result, delaySecond, true));
    }

    public void TransScene(SceneAsset scene)
    {
        StartCoroutine(transition(scene, delaySecond, false));
    }

    IEnumerator transition(SceneAsset scene, float delay, bool stage)
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
