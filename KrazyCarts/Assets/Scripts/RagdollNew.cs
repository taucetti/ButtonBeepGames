//Followed this tutorial https://www.youtube.com/watch?v=Iyqo-hjLg20&list=PLx7AKmQhxJFaZXE1c0wqc35l4kau-WCNA&index=2&pp=iAQB

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollNew : MonoBehaviour
{

    public Rigidbody[] _ragdollRigidbodies;
    public CharacterController characterController;
    public Animator animator;
    private float timeToRevive;
    private StayAtOrigin stayAtOrigin;
    
    void Awake()
    {
        //Get the list of ragdoll joints
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        //Get a reference to the script that locks the player model at the origin point
        stayAtOrigin = GetComponent<StayAtOrigin>();
        //Disable the ragdoll
        DisableRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToRevive > 0f)
        {
            //Decrease the time to revive is there is time left
            timeToRevive -= Time.deltaTime;

            //If the timer goes below zero, restore the position and reset the rotation, then disable the ragdoll
            if (timeToRevive <= 0)
            {
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;

                DisableRagdoll();
            }
        }
    }

    private void DisableRagdoll()
    {
        //Disable the character controller so the player can move again
        characterController.enabled = true;

        //Lock the player model to the origin
        if (stayAtOrigin != null)
        {
            stayAtOrigin.enabled = true;
        }

        //Enable the animator
        animator.enabled = true;

        //Set all the joints to be kinematic
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    private void EnableRagdoll()
    {
        //Disable the character controller so the player can't move while "dead"
        characterController.enabled = false;

        //Allow the player model to move from the origin
        if (stayAtOrigin != null)
        {
            stayAtOrigin.enabled = false;
        }

        //Disable the animator to avoid issues with the ragdoll
        animator.enabled = false;

        //Disable kinematics on each joint
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovingCars"))
        {
            //Set the revive timer to between 3 and 5 seconds
            timeToRevive = Random.Range(3, 5);

            EnableRagdoll();
        }
    }
}
