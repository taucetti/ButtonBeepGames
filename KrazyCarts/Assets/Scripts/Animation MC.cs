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
    Rigidbody mC;

    private Animator animator;
    private string currentAnimation = "";

   //bool isIdle = false;
    //bool cartCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        mC = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //cartCollected = false;
        changeAnimation("Walk");
    }

    // Update is called once per frame
    void FixedUpdate()

        movement = new Vector2(Input.GetAxisRaw("Horizontal") Input.GetAxisRaw("Vertical"));
    //{
       // if (Input.GetKeyDown(KeyCode.W))
       // {
          //  if (isGrounded)
           //     animator.Play("isWalking");
           // else if (isGrounded)
          //  {
           //     cartCollected = true;
           //     isIdle = false;
           //     animator.Play("Pushing Cart Walk");
           // }
       // }//else if (Input.GetKeyDown(KeyCode.None))
        //{
         //   if (isGrounded && !isIdle)
        //        animator.Play("Idle no cart");
         //   else if (!isGrounded && !isIdle)
            {
        //        cartCollected = true;
                //sisIdle = true;
        //        animator.Play("Idle with cart");
        //    }

       // }
      //  else if (Input.GetKeyDown(KeyCode.LeftShift))
       // {
         //   if (isGrounded)
        //        animator.Play("isrunning");
       //     else if (isGrounded)
       //     {
       //         cartCollected = true;
       //         isIdle = false;
       //         animator.Play("runWithCart");
         //   }

       // }

    }
    private void CheckAnimation()
    {

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
