using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_BrandBag : BaseEvent
{
    protected override void Start()
    {
        base.Start();
        manager.TalkEvent(2);
    }
}
