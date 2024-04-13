using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomEventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent customClick;
    Vector2 beginPos;

    public void OnPointerDown(PointerEventData eventData)
    {
        Clear();
        beginPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Vector2.Distance(beginPos, eventData.position) < 1.0f)
        {
            customClick.Invoke();
        }

        Clear();
    }

    void Clear()
    {
        beginPos = Vector2.zero;
    }
}
