using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Image image;
    float fadeSec = 1.0f;
    bool fadeOut = false;
    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {

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
        }
        else
        {
            if (0 < a)
            {
                a -= 1 / fadeSec * Time.deltaTime;
            }
        }

        image.color = new Color(0, 0, 0, a);
    }

    public void Fade(float sec)
    {
        fadeSec = sec;
        fadeOut = !fadeOut;

        StartCoroutine(hideCanvas());
    }

    IEnumerator hideCanvas()
    {
        if (canvas != null)
        {
            if (fadeOut)
            {
                canvas.enabled = false;
            }
            else
            {
                yield return new WaitForSeconds(fadeSec);
                canvas.enabled = true;
            }
        }
    }
}
