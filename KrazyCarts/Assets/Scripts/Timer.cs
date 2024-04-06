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


    public class Timer3 : MonoBehaviour
    {
        public float timeRemaining = 210f;
        public float endTime = 0f;
        public bool timerRunning = false;
        public Text timerText;


        // Start is called before the first frame update
        void Start()
        {
            timerRunning = true;
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
                }
                else
                {
                    timerRunning = false;
                    timeRemaining = 0;
                    timerText.text = string.Format("Time Remaining: 0:00");
                }
            }



        }


        void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60); //divide total by 60, full number is minutes
            float seconds = Mathf.FloorToInt(timeToDisplay % 60); //divide total by 60, remainder is seconds
            timerText.text = string.Format("Time Remaining: {0:00}:{1:00}", minutes, seconds);
        }
    }
}
