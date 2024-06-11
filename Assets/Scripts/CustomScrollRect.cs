using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomScrollRect : ScrollRect
{
    Panel panel;

    protected override void Start()
    {
        base.Start();
        panel = GameObject.Find("SearchPanel").GetComponent<Panel>();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        //base.OnBeginDrag(eventData);
        panel.OnBeginDrag(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        //base.OnDrag(eventData);
        panel.OnDrag(eventData);
    }
}
