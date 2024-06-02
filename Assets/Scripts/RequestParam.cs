using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Create RequestParam")]
public class RequestParam : ScriptableObject
{
    public string SceneName = string.Empty;
    public bool Answer = false;
    public List<TalkLines> events;
}

[System.Serializable]
public class TalkLines
{
    public List<string> lines;
}
