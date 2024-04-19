using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public KeyCode resetKey;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private CharacterController characterController;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(resetKey))
        {
            //The character controller always overrides the transform position for some reason, so it must be disabled while changing the position
            characterController.enabled = false;
            transform.position = originalPosition;
            characterController.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingCars"))
        {
            originalPosition = collision.gameObject.transform.position;
            originalRotation = transform.rotation;
            StartCoroutine(ResetPos(3));
        }
    }

    IEnumerator ResetPos(int waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        transform.position = originalPosition;
        transform.position += new Vector3(0f, 5f, 0f);
        transform.rotation = originalRotation;
    }
}
