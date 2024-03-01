using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRagdoll : MonoBehaviour
{
    private Rigidbody[] ragdollRigidbodies;

    void Awake()
    {// Will get all rigid bodies in scene and disable ragdoll on awake
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

  
    void Update()
    {//Used for testing when seeing if ragdoll works on space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnableRagdoll();
        }
    }
    //function to disable ragdoll
    private void DisableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }
    //function to enable ragdoll, used when pressing space
    private void EnableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }
}
