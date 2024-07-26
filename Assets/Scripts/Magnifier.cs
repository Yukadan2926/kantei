using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnifier : MonoBehaviour
{
    public GameObject subCameraObject;
    GameObject cameraInstance = null;
    Camera cameraInstComp = null;

    public GameObject magnifier;
    GameObject magnifierInstance = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cameraInstance != null)
        {
            Vector3 scpoint = Input.mousePosition;
            scpoint.z = 1.0f;
            cameraInstance.transform.LookAt(Camera.main.ScreenToWorldPoint(scpoint));

            magnifierInstance.transform.position = Input.mousePosition;
        }
    }

    public void ToggleEnable()
    {
        if (cameraInstance == null)
        {
            cameraInstance = Instantiate(subCameraObject);
            cameraInstComp = cameraInstance.GetComponent<Camera>();

            magnifierInstance = Instantiate(magnifier, transform.parent);
        }
        else
        {
            Destroy(cameraInstance);
            cameraInstance = null;

            Destroy(magnifierInstance);
            magnifierInstance = null;
        }
    }
}
