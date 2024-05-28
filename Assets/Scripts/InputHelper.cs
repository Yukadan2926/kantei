using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputHepler
{
    private static Vector3 StartTouchPosition;

    /// <summary>
    /// マウスの左クリックでドラッグした際にレイキャストでヒットした開始と終了座標を返す
    /// </summary>
    public static void GetMouseDragFromTo(Transform target, Camera camera, 
        out RaycastHit from, out RaycastHit to)
    {
        from = new RaycastHit();
        to = new RaycastHit();

        //  ドラッグ開始位置を保存
        if (Input.GetMouseButtonDown(1))
        {
            StartTouchPosition = Input.mousePosition;
        }

        //  ドラッグ中は前フレームとの差を加算する
        if (Input.GetMouseButton(1))
        {
            //  カメラ方向から見たドラッグの回転角を計算

            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit))
            {
                return;
            }

            var ray2 = camera.ScreenPointToRay(StartTouchPosition);
            if (!Physics.Raycast(ray2, out var hit2))
            {
                return;
            }

            from = hit2;
            to = hit;

            StartTouchPosition = Input.mousePosition;
        }
    }
}