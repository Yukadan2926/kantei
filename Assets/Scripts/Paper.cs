﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Paper : MonoBehaviour
{
    [SerializeField] float moveSec = 0.2f;

    bool isClicked = false;
    Vector3 targetPos;
    Quaternion targetRot;
    Vector3 putPos;
    Quaternion putRot;
    float t;
    Vector3 pointDist;
    float nearest;
    float distance;
    public bool onPointer { get; set; } = false;

    private void Start()
    {
        putPos = targetPos = transform.position;
        putRot = targetRot = transform.rotation;

        distance = 2.0f;
        nearest = 0.5f;

        CustomEventClick click = gameObject.AddComponent<CustomEventClick>();
        click.customClick = new UnityEvent();
        click.customClick.AddListener(OnClick);

        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.BeginDrag;
        entry.callback.AddListener(ProcDistance);
        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback.AddListener(DragMove);
        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { onPointer = true; });
        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((data) => { onPointer = false; });
        trigger.triggers.Add(entry);
    }

    private void Update()
    {
        if (t <= 1.0f)
        {
            float ft = -1 * t * t + 2 * t;
            transform.position = Vector3.Lerp(putPos, targetPos, ft);
            transform.rotation = Quaternion.Lerp(putRot, targetRot, ft);

            t += 1.0f / moveSec * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0 && isClicked && onPointer)
        {
            distance -= scroll;
            distance = Mathf.Clamp(distance, nearest, 3.0f);

            transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
        }
    }

    public void OnClick()
    {
        isClicked = !isClicked;
        t = 0;

        if (isClicked)
        {
            putPos = transform.position;
            putRot = transform.rotation;
            targetPos = Camera.main.transform.position + Camera.main.transform.forward * distance;
            targetRot = Quaternion.LookRotation(Camera.main.transform.forward * -1);
        }
        else
        {
            targetPos = putPos;
            targetRot = putRot;
            putPos = transform.position;
            putRot = transform.rotation;
        }
    }

    public void DragMove(BaseEventData data)
    {
        Vector3 pos = Input.mousePosition;

        if (isClicked)
        {
            pos.z = distance;
            transform.position = Camera.main.ScreenToWorldPoint(pos) + pointDist;
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 p = hit.point + pointDist;

                if (-3.6 < p.x && p.x < 3.6)
                {
                    Vector3 x = transform.position;
                    x.x = p.x;
                    transform.position = x;
                }
                if (-2.2 < p.z && p.z < 0.8)
                {
                    Vector3 z = transform.position;
                    z.z = p.z;
                    transform.position = z;
                }
            }
        }
    }

    public void ProcDistance(BaseEventData data)
    {
        Vector3 pos = Input.mousePosition;

        if (isClicked)
        {
            pos.z = distance;
            pointDist = transform.position - Camera.main.ScreenToWorldPoint(pos);
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                pointDist = transform.position - hit.point;
            }
        }
    }
}
