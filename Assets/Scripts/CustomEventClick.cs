using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomEventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent customClick;

    Vector2 beginPos;
    float beginTime;

    public void OnPointerDown(PointerEventData eventData)
    {
        beginPos = eventData.position;
        beginTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Vector2.Distance(beginPos, eventData.position) < 10.0f &&
            Time.time - beginTime < 0.5f)
        {
            customClick.Invoke();
        }
    }
}
