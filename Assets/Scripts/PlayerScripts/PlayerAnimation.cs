using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void IdleAnimation()
    {
        anim.Play("Idle");
    }

    public void PullingItemAnimation()
    {
        anim.Play("Rope Wrap");
    }

    public void CheerAnimation()
    {
        anim.Play("Cheer");
    }
}
