using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartCollision : MonoBehaviour
{
    public ThirdPersonControllerM controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider car)
    {
        // If Collision with cars is detected the players Walking/ Running will be reversed until until Collision is ended
        if(car.gameObject.CompareTag("Cars"))
        {
            // Script that if a Cart enters a cart the player rebounds
            controller.walkingSpeed = -7.5f;
            controller.runningSpeed = -11.5f;
           
        }
    }
    void OnTriggerStay(Collider car)
    {
        // If Collision with cars is detected the players Walking/ Running will be reversed until until Collision is ended
        if (car.gameObject.CompareTag("Cars"))
        {
            // Script that if a cart stays collided itll be forced backwards
            controller.walkingSpeed = -7.5f;
            controller.runningSpeed = -11.5f;
        }

    }
    void OnTriggerExit(Collider car)
    {
        // Script that when a carts leaves the cart the player regains controls
        if (car.gameObject.CompareTag("Cars"))
        {
            controller.walkingSpeed = 7.5f;
            controller.runningSpeed = 11.5f;
         
        }
    }
    
}
