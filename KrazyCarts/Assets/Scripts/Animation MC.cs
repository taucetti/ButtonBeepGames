using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationMC : MonoBehaviour
{

    //public float walkSpeed = 7.5f;
    //public float runSpeed = 11.5f;
    
   // private bool isGrounded = true;
    //Rigidbody mC;

    private Animator animator;
    private string currentAnimation = "";
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
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        CheckAnimation();
    }

     private void CheckAnimation()
    {
        if(movement.y == 1)
        {
            changeAnimation("Walk");
        }
        else if((movement.y == 0) && (movement.x ==0))
        {
            changeAnimation("Idle no cart");
        }
        else if ((movement.y == 1) && (CartCollection = true))
        {
            changeAnimation("Pushing Cart Walk");
        }
        else if ((movement.y == 0) && (movement.x == 0) && (CartCollection = true))
        {
            changeAnimation("Idle with cart");
        }
        else if (movement.y > 1)
        {
            changeAnimation("Running");
        }
    }
    private void changeAnimation(string animation, float crossfade = 0.2f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossfade);
        }

    }
}
