using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField]  Animator animator;

    public void Surprise(bool b)
    {
        animator.SetBool("Bikkuri", b);
    }

    public void Happy(bool b)
    {
        animator.SetBool("Happy", b);
    }
}
