using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavierController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.ResetTrigger("MCinCollider");
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("MCinCollider");
    }

    private void OnTriggerExit(Collider other)
    {
        animator.ResetTrigger("MCinCollider");
    }
}
