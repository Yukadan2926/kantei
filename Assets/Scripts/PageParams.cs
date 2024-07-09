using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PageData", menuName = "ScriptableObjects/Create PageParams")]
public class PageParams : ScriptableObject
{
    public List<PageParam> pages = new List<PageParam>();
}

[System.Serializable]
public class PageParam
{
    public string objectName;
    public bool madeOfImage;
    public bool visibleInSuggest;
    public string title;
    [TextArea(5, 5)]
    public string description;
}
