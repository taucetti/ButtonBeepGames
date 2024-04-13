using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartCollision : MonoBehaviour
{
    //public ThirdPersonControllerM controller;
    //public AchievementResults results;
    //private float timeTillHitAgain = 5f;

    //public LoadEnding checker;
    public PauseManager pauseMenu;

    //Marks whether the cart is colliding with a car or not
    private bool isInCar;
    //Determines the direction the cart will travel in order to get out of the car
    private Vector3 escapeDirection = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (checker.gameWon != true && checker.gameLost != true && !pauseMenu.isPaused)
        {
            timeTillHitAgain -= Time.deltaTime;
        }
        */

        //If the cart is colliding with a car, move the cart's position according to the escape direction
        //The escape direction is determined when the cart first collides with the car
        if (isInCar && !pauseMenu.isPaused)
        {
            transform.position += escapeDirection;
        }
    }

    void OnTriggerEnter(Collider car)
    {
        if (car.gameObject.CompareTag("Cars"))
        {
            //Mark the cart as being in the car
            isInCar = true;

            //Reset the escape direction
            escapeDirection = new Vector3(0, 0, 0);



            //Determine the escape direction according to the cart's and the car's position
            if (transform.position.x < car.gameObject.transform.position.x)
            {
                escapeDirection.x = -0.1f;
            }
            else
            {
                escapeDirection.x = 0.1f;
            }

            if (transform.position.z < car.gameObject.transform.position.z)
            {
                escapeDirection.z = -0.1f;
            }
            else
            {
                escapeDirection.z = 0.1f;
            }
        }

        /*
        // If Collision with cars is detected the players Walking/ Running will be reversed until until Collision is ended
        if(car.gameObject.CompareTag("MovingCars"))
        {
            // Script that if a Cart enters a cart the player rebounds
            controller.walkingSpeed = -7.5f;
            controller.runningSpeed = -11.5f;

            if(timeTillHitAgain < 0)
            {
                results.movingCars++;
                Debug.Log(results.movingCars);
                timeTillHitAgain = 5;
            }
            
        }
        */
    }

    void OnTriggerExit(Collider car)
    {
        if (car.gameObject.CompareTag("Cars"))
        {
            //Mark the that cart is no longer colliding with a car
            isInCar = false;

            //Reset the escape direction
            //Not essential but I prefer keeping data tidy
            escapeDirection = Vector3.zero;
        }

        /*
        // Script that when a carts leaves the cart the player regains controls
        if (car.gameObject.CompareTag("MovingCars"))
        {
            controller.walkingSpeed = 7.5f;
            controller.runningSpeed = 11.5f;
         
        }
        */
    }
    
}
