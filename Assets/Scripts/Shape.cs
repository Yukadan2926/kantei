using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shape : MonoBehaviour
{
    bool isClicked = false;
    Vector3 targetPos;
    Quaternion targetRot;
    Vector3 putPos;
    Quaternion putRot;
    float t;

    [SerializeField] float moveSec = 1.0f;
    [SerializeField] float distance = 1.0f;

    Vector3 pointDist;
    EventTrigger trigger;

    [SerializeField] float rollSpeed = 1.0f;
    bool rolling = false;

    private void Start()
    {
        putPos = targetPos = transform.position;
        putRot = targetRot = transform.rotation;


        trigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.BeginDrag;
        entry1.callback.AddListener(ProcDistance);

        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.Drag;
        entry2.callback.AddListener(DragMove);

        trigger.triggers.Add(entry1);
        trigger.triggers.Add(entry2);
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

    void DragMove(BaseEventData eventData)
    {
        Vector3 pos = Input.mousePosition;

        if (isClicked)
        {
            rolling = true;
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

    void ProcDistance(BaseEventData eventData)
    {
        if (isClicked)
        {

        }
        else
        {
            Vector3 pos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                pointDist = transform.position - hit.point;
            }
        }
    }
}
