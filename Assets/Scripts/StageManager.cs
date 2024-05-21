﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class StageManager : MonoBehaviour
{
    public int index = 0;
    public RequestParam[] requests;

    [SerializeField] Button realButton;
    [SerializeField] Button fakeButton;

    private void Start()
    {
        ScoreLoader.Score = 0;
        requests = StageSelector.RequestList;

        TalkPanel.Hide(true);
    }

    public void AddScore()
    {
        ScoreLoader.Score += 1;
    }

    public void AddOnClickCallack()
    {
        realButton.onClick.RemoveAllListeners();
        fakeButton.onClick.RemoveAllListeners();

        if (requests[index].Answer)
        {
            realButton.onClick.AddListener(AddScore);
        }
        else
        {
            fakeButton.onClick.AddListener(AddScore);
        }
    }
}
