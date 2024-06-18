﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Shape : MonoBehaviour
{
    bool isClicked = false;
    Vector3 targetPos;
    Quaternion targetRot;
    Vector3 putPos;
    Quaternion putRot;
    float t;

    [SerializeField] float moveSec = 0.2f;
    float nearest;
    float distance;

    Vector3 pointDist;

    float rollSpeed = 1.0f;
    bool rolling = false;

    public bool onPointer { get; set; } = false;
    SphereCollider sphere;

    EventTrigger trigger;

    private void Start()
    {
        putPos = targetPos = transform.position;
        putRot = targetRot = transform.rotation;

        sphere = transform.Find("collider").gameObject.GetComponent<SphereCollider>();
        
        distance = 3.0f;
        nearest = sphere.radius + 0.5f;
        rollSpeed = 30 - (distance - nearest) * 10;


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

        if (isClicked)
        {
            //  平面上のドラッグから、球面上のドラッグ区間（AB）を求める
            InputHepler.GetMouseDragFromTo(transform, Camera.main, out var from, out var to);

            var fromPos = Vector3.zero;
            var toPos = Vector3.zero;
            if (from.collider != null && 
                to.collider != null &&
                from.collider.gameObject.CompareTag("Shape") &&
                to.collider.gameObject.CompareTag("Shape"))
            {
                fromPos = from.point;
                toPos = to.point;
            }
            else
            {
                rolling = false;
            }

            if (rolling)
            {
                //  回転軸axisは、球面上の中心点（O）とABからなる平面の法線
                var vecA = fromPos - transform.position;
                var vecB = toPos - transform.position;
                var axis = Vector3.Cross(vecA, vecB);

                //  球面上の中心点（O）から軸axisに対する回転角度（θ）を求める
                var dragAngle = Vector3.SignedAngle(fromPos, toPos, axis);

                //  回転軸axisに対してθ回転させる
                transform.Rotate(axis, dragAngle * rollSpeed, Space.World);
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0 && isClicked && onPointer)
        {
            distance -= scroll;
            distance = Mathf.Clamp(distance, nearest, 3.0f);

            rollSpeed = 30 - (distance - nearest) * 10;

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
            rolling = true;

            if (!Input.GetMouseButton(0))
            {
                return;
            }

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
            if (!Input.GetMouseButton(0))
            {
                return;
            }

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
