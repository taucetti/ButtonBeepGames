using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Animations;
using UnityEngine;

public class AnimationMC : MonoBehaviour
{

    public float walkSpeed = 7.5f;
    public float runSpeed = 11.5f;
    
   private bool isGrounded = true;
    //Rigidbody mC;

    private Animator animator;
   // private string currentAnimation = "";
    private Vector3 movement;

    public bool CartCollection { get; private set; }

    //bool isIdle = false;
    //bool cartCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        //mC = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //cartCollected = false;
        //changeAnimation("Walk");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //for animations
        //bool movementPressed = animator.GetBool(movementPressedHash);
        bool forwardPressed = Input.GetKey("w");
        bool isEmoting = Input.GetKey("f");
        bool getCartHeld = true;
        //isRunning boolean is already called at top of update function
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);


        //walking
        if (forwardPressed)
        {
            animator.SetBool("Movement Pressed", true);
        }
        //not walking, back to idle without cart
        if (!forwardPressed && !getCartHeld)
        {
            animator.SetBool("Movement Pressed", false);
        }
        //running 
        if (isRunning && forwardPressed)
        {
            animator.SetBool("Shift Pressed", true);
            animator.SetBool("Movement Pressed", true);
        }
        //not running, back to idle without cart
        if (!isRunning && (!forwardPressed && isRunning) && !getCartHeld)
        {
            animator.SetBool("Shift Pressed", false);
            animator.SetBool("Movement Pressed", false);
            animator.SetBool("Cart Held", false);
        }
        //back to walk from running
        if (forwardPressed && !isRunning)
        {
            animator.SetBool("Movement Pressed", true);
            animator.SetBool("Shift Pressed", false);
        }
        //idle with cart
        if (!forwardPressed && getCartHeld)
        {
            animator.SetBool("Movement Pressed", false);
            animator.SetBool("Cart Held", true);

        }
        // idle without cart
        if (!forwardPressed && !getCartHeld)
        {
            animator.SetBool("Movement Pressed", false);
            animator.SetBool("Cart Held", false);
        }
        //emoting when its added
        if (isEmoting)
        {
            animator.SetBool("isEmoting", true);
        }

        if (!isEmoting && forwardPressed)
        {
            animator.SetBool("isEmoting", false);
            animator.SetBool("Movement Pressed", true);
        }

        //walking with cart/ Cart pushing
        if (forwardPressed && getCartHeld)
        {
            animator.SetBool("Movement Pressed", true);
            animator.SetBool("Cart Held", true);
        }
        //running with cart?
        //if (!isRunning && getCartHeld)
        //{
        //   animator.SetBool("Shift Pressed", true);
        //   animator.SetBool("Cart Held", true);
        // }
    }
}
    

     
    

