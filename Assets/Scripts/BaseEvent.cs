using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseEvent : MonoBehaviour
{
    protected StageManager manager;

    [SerializeField] UnityEvent unityEvent;

    protected virtual void Start()
    {
        manager = GetComponent<StageManager>();
    }

    public virtual void EndEvent(bool chose)
    {
        manager.TalkEvent(chose ? 0 : 1);
    }

    public void EventInvoke()
    {
        unityEvent.Invoke();
    }
}
