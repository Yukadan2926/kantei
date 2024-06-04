using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Figure : BaseEvent
{
    [SerializeField] Canvas appraisePanel;
    bool completeTuterial = false;

    protected override void Start()
    {
        base.Start();
        manager.TalkEvent(2);
    }

    private void Update()
    {
        if (completeTuterial)
        {
            if (appraisePanel.enabled)
            {
                EventInvoke();
            }
        }
    }
}
