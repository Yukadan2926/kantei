using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class StageManager : MonoBehaviour
{
    public int index = 0;
    public string[] requests;

    [SerializeField] Button realButton;
    [SerializeField] Button fakeButton;

    private void Start()
    {
        ScoreLoader.Score = 0;
        requests = StageSelector.RequestList;
    }

    public void AddScore()
    {
        Debug.Log("true");
        ScoreLoader.Score += 1;
    }

    public void AddOnClickCallack()
    {
        realButton.onClick.RemoveAllListeners();
        fakeButton.onClick.RemoveAllListeners();

        var path = $"{requests[index]}_Data";
        var requestData = Resources.Load(path) as RequestParam;
        if (requestData.Answer)
        {
            realButton.onClick.AddListener(AddScore);
            Debug.Log("real");
        }
        else
        {
            fakeButton.onClick.AddListener(AddScore);
            Debug.Log("fake");
        }
    }
}
