using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Animations : MonoBehaviour
{
    public Animator animator;

    public void WalkCasual()
    {
        animator.SetBool("isWalkingCasual", true);
    }

    public void WalkJaunty()
    {
        animator.SetBool("isWalkingJaunty", true);
    }

    public void Run()
    {
        animator.SetBool("isRunning", true);
    }

    public void Sit()
    {
        animator.SetBool("isSitting", true);
    }

    public void Eat()
    {
        animator.SetTrigger("eat");
    }
}
