using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputHepler
{
    private static Vector3 StartTouchPosition;

    /// <summary>
    /// �}�E�X�̍��N���b�N�Ńh���b�O�����ۂɃ��C�L���X�g�Ńq�b�g�����J�n�ƏI�����W��Ԃ�
    /// </summary>
    public static void GetMouseDragFromTo(Transform target, Camera camera, 
        out RaycastHit from, out RaycastHit to)
    {
        from = new RaycastHit();
        to = new RaycastHit();

        //  �h���b�O�J�n�ʒu��ۑ�
        if (Input.GetMouseButtonDown(0))
        {
            StartTouchPosition = Input.mousePosition;
        }

        //  �h���b�O���͑O�t���[���Ƃ̍������Z����
        if (Input.GetMouseButton(0))
        {
            //  �J�����������猩���h���b�O�̉�]�p���v�Z

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