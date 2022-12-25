using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatControl : MonoBehaviour
{
    protected Animator charAnimate;

    void Start()
    {
        charAnimate = gameObject.GetComponent<Animator>();
        PlayerScript.Instance.onDie += Death;
    }

    public virtual void Update()
    {
        AnimeWalk(Input.GetAxisRaw("Horizontal"));
    }
    protected void AnimeWalk(float horizontal)
    {
        if (horizontal == 0)
        {
            charAnimate.SetBool("g_bWalk", false);
        }
        else
        {
            charAnimate.SetBool("g_bWalk", true);
        }
    }

    void Death()
    { 
        charAnimate.SetTrigger("tDie"); 
    }
}