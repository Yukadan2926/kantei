using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanvas : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    private void Start()
    {
        canvas.worldCamera = Camera.main;
    }
}
