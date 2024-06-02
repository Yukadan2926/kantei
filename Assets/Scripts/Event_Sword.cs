using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Event_Sword : BaseEvent
{
    protected override void Start()
    {
        base.Start();
        manager.TalkEvent(2);
    }
}
