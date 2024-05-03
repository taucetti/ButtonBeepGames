using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFadeOut : MonoBehaviour
{
    public float secondsVisible;

    private CanvasGroup buttonCanvas;
    private float activeTimer;

    private void Start()
    {
        buttonCanvas = GetComponent<CanvasGroup>();     //Get the canvas from the attached object
        buttonCanvas.alpha = 0f;    //Set the button to be invisible to start
        activeTimer = 0f;   //Set the active timer to zero
    }

    private void Update()
    {
        //If any input is detected, set the button to be visible and start the active timer
        if (Input.anyKeyDown)
        {
            buttonCanvas.alpha = 1f;
            activeTimer = secondsVisible;
        }

        //If the active timer has time left, decrease the time
        if (activeTimer > 0f)
        {
            activeTimer -= Time.deltaTime;
        }
        //If the timer has ended...
        else
        {
            //If the button is still visible, decrease the opacity
            if (buttonCanvas.alpha > 0f)
            {
                buttonCanvas.alpha -= Time.deltaTime;
            }
        }
    }
}
