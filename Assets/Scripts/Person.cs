using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField]  Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Surprise(bool b)
    {
        animator.SetBool("Bikkuri", b);
    }

    public void Happy(bool b)
    {
        animator.SetBool("Happy", b);
    }
}
