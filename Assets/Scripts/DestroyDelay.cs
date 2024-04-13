using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    [SerializeField] float delay = 3.0f;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.realtimeSinceStartup - startTime;

        if (elapsedTime > delay)
        {
            Destroy(gameObject);
        }
    }
}
