using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartCollision : MonoBehaviour
{
    public ThirdPersonControllerM controller;
    public AchievementResults results;
    private float timeTillHitAgain = 5f;

    public LoadEnding checker;
    public PauseManager pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checker.gameWon != true && checker.gameLost != true && !pauseMenu.isPaused)
        {
            timeTillHitAgain -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider car)
    {
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
    }
    
    void OnTriggerExit(Collider car)
    {
        // Script that when a carts leaves the cart the player regains controls
        if (car.gameObject.CompareTag("MovingCars"))
        {
            controller.walkingSpeed = 7.5f;
            controller.runningSpeed = 11.5f;
         
        }
    }
    
}
