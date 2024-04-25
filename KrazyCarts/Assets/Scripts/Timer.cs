using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 //This gives us access to our UI elements so we can display the text. Only using it internally? Don't need it.
using TMPro;
using UnityEngine.UI;

//This is a basic timer good for counting down seconds.
//It counts down as full seconds and stops immediately when you get to 0

public class Timer : MonoBehaviour
{
    public float timeRemaining = 210f;
    public float endTime = 0f;
    public bool timerRunning = false;
    public TextMeshProUGUI timerText;
    public bool playedOnce = false; // Prevents from playing continuously

    public AudioSource soundClip;
    public AudioClip lowTime;

    Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
        playedOnce = false;

        if (timerText != null)
        {
            originalColor = timerText.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > endTime)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                if((int)timeRemaining == 14 && !playedOnce)
                {
                    soundClip.PlayOneShot(lowTime);
                    Debug.Log("Low on Time");
                    playedOnce = true;
                }

                // This will make the timer flash when running out of time
                if (((int)timeRemaining % 2 == 0) && playedOnce)
                {
                    timerText.color = Color.red;
                }
                else
                {
                    timerText.color = originalColor;
                }
            }
            else
            {
                timerRunning = false;
                timeRemaining = 0;
                timerText.text = string.Format("Time: 0:00");
                timerText.color = Color.black;
            }
        }



    }


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //divide total by 60, full number is minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //divide total by 60, remainder is seconds
        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
    
}
