using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartCollision : MonoBehaviour
{
    [SerializeField] ThirdPersonControllerM walkingSpeed;
    [SerializeField] ThirdPersonControllerM runningSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // If Collision with cars is detected the players Walking/ Running will be reversed until until Collision is ended
        if(other.tag =="Cars")
        {
           // walkingSpeed = -7.5f;
           // runningSpeed = -11.5f;
        }
    }
    
}
