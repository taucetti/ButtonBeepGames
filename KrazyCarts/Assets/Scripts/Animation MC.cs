using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationMC : MonoBehaviour
{

    public float walkSpeed = 7.5f;
    public float runSpeed = 11.5f;

    private bool isGrounded = true;
    Rigidbody mC;

    Animator animation;

    bool isIdle = false;
    bool cartCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        mC = GetComponent<Rigidbody>();
        animation = GetComponent<Animator>();
        cartCollected = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
                animation.Play("isWalking");
            else if (isGrounded)
            {
                cartCollected = true;
                isIdle = false;
                animation.Play("Pushing Cart Walk");
            }
        }
        else if (Input.GetKeyDown(KeyCode.None))
        {
            if (isGrounded && !isIdle)
                animation.Play("Idle no cart");
            else if (!isGrounded && !isIdle)
            {
                cartCollected = true;
                isIdle = true;
                animation.Play("Idle with cart");
            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isGrounded)
                animation.Play("isrunning");
            else if (isGrounded)
            {
                cartCollected = true;
                isIdle = false;
                animation.Play("runWithCart");
            }

        }

    }
}
