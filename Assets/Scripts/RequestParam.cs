using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Create RequestParam")]
public class RequestParam : ScriptableObject
{
    public string SceneName = string.Empty;
    public bool Answer = false;
}
