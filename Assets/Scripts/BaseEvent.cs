using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEvent : MonoBehaviour
{
    protected StageManager manager;

    protected virtual void Start()
    {
        manager = GetComponent<StageManager>();
    }

    public virtual void EndEvent(bool chose)
    {
        manager.TalkEvent(chose ? 0 : 1);
    }
}
