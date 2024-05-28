using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    Vector3 dist;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void DragMove()
    {
        Vector3 pos = Vector3.zero;
        pos.x = Input.mousePosition.x + dist.x;
        pos.y = Input.mousePosition.y + dist.y;
        transform.localPosition = pos;
    }

    void ProcDistance()
    {
        dist = transform.position - Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ProcDistance();
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragMove();
    }
}
