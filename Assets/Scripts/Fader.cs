using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] float fadeSec = 1.0f;
    [SerializeField] Image image;
    bool fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        image.color = new Color(0, 0, 0, 0);
        fadeOut = true;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float a = image.color.a;
        if (fadeOut)
        {
            if (a < 1)
            {
                a += 1 / fadeSec * Time.deltaTime;
            }
            else
            {
                fadeOut = false;
            }
        }
        else
        {
            if (0 < a)
            {
                a -= 1 / fadeSec * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        image.color = new Color(0, 0, 0, a);
    }
}
