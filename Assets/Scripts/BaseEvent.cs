using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseEvent : MonoBehaviour
{
    protected StageManager manager;

    protected virtual void Start()
    {
        manager = GetComponent<StageManager>();
        OpeningEvent();
    }

    public virtual void OpeningEvent()
    {
        manager.TalkEvent(0);
    }

    public virtual void EndingEvent(bool chose)
    {
        manager.TalkEvent(chose ? 1 : 2);
    }
}
