using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    Vector3 dist;
    EventTrigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        //trigger = gameObject.AddComponent<EventTrigger>();

        //EventTrigger.Entry entry1 = new EventTrigger.Entry();
        //entry1.eventID = EventTriggerType.BeginDrag;
        //entry1.callback.AddListener(ProcDistance);

        //EventTrigger.Entry entry2 = new EventTrigger.Entry();
        //entry2.eventID = EventTriggerType.Drag;
        //entry2.callback.AddListener(DragMove);

        //trigger.triggers.Add(entry1);
        //trigger.triggers.Add(entry2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DragMove(BaseEventData eventData)
    {
        Vector3 pos = Vector3.zero;
        pos.x = Input.mousePosition.x + dist.x;
        pos.y = Input.mousePosition.y + dist.y;
        transform.position = pos;
    }

    void ProcDistance(BaseEventData eventData)
    {
        dist = transform.position - Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ProcDistance(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragMove(eventData);
    }
}
