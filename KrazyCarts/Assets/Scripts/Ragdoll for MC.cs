using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RagdollforMC : MonoBehaviour

{
    [SerializeField] GameObject _Controller;
    public BoxCollider mainCollider;
    public GameObject MCRig;
    //public animator when animations are added
    Vector3 startPosition;
    Quaternion startRotation;

    void Start()
    {
        GetRagdollParts();
        RagdollModeOff();

        Position = transform.position;
        rotation = transform.rotation;
    }

    private float timeToWakeUp;

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

    private void resetMCLoc()
    {
        
    }

    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidBodies;

    public Vector3 Position { get; private set; }

    private Quaternion rotation;

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
        timeToWakeUp = Random.Range(2, 5);
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
    void RagdollBehaviour()
    {
        timeToWakeUp -= Time.deltaTime;
        if (timeToWakeUp <= 0) 
        {
            
        }
    }

}


