using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RagdollforMC : MonoBehaviour

{
    public BoxCollider mainCollider;
    public GameObject MCRig;
    //public animator when animations are added
    void Start()
    {
        GetRagdollParts();
        RagdollModeOff();

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cars"))
        {
            RagdollModeOn();

        }

    }

    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidBodies;

    void GetRagdollParts()
    {
        ragDollColliders = MCRig.GetComponentsInChildren<Collider>();
        limbsRigidBodies = MCRig.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollModeOn()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rigid in limbsRigidBodies)
        {
            rigid.isKinematic = false;
        }

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void RagdollModeOff()
    {
        foreach(Collider col in ragDollColliders)
        {
            col.enabled = false;
        }

        foreach(Rigidbody rigid in limbsRigidBodies)
        {
            rigid.isKinematic = true;
        }

        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;


    }

}


