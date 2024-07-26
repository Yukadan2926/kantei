using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EdgeInfo : MonoBehaviour
{
    public NodeInfo after;
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        GameObject.Find("StageSelector").GetComponent<StageSelector>().edgeList.Add(this);
    }

    public void SetConnect(int flg)
    {
        if (flg == 0)
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;

            if (flg == 1)
            {
                transform.localScale = new Vector3(0.2f, 1.0f, 1.0f);
            }
            else if (flg == 2)
            {
                transform.localScale = Vector3.one;
            }
        }
    }
}
