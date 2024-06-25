using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mc;

    // Start is called before the first frame update
    void Start()
    {
        mc = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (mc != null)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                mc.fieldOfView = 20;
            }
            else
            {
                mc.fieldOfView = 60;
            }
        }
    }
}
