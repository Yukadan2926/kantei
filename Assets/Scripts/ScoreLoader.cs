using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLoader : MonoBehaviour
{
    public static int Score = 0;

    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = $"{Score} / {StageSelector.RequestList.Length}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
