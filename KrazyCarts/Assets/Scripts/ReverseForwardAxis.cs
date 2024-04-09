using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;  //Used to manipulate spline animators

public class ReverseForwardAxis : MonoBehaviour
{
    public float time;          //Saves the current time given by the spline animator
    public float previousTime;  //Saves the previously recorded time from the spline animator
    private SplineAnimate splineAnimator;   //The spline animator
    
    // Start is called before the first frame update
    void Start()
    {
        //Set the time variables to default values
        time = 0;
        previousTime = -1;
        //Get the spline animator from the game object
        splineAnimator = GetComponent<SplineAnimate>();
    }

    // Update is called once per frame
    void Update()
    {
        //This whole section assumes that the spline is set to ping pong

        //Get the time from the spline animator
        time = splineAnimator.NormalizedTime;

        //If time is flowing forward set the forward axis to positive z
        if (time > previousTime)
        {
            splineAnimator.ObjectForwardAxis = SplineComponent.AlignAxis.ZAxis;
        }
        //Otherwise time is flowing backwards so set the forward axis to negative z;
        else
        {
            splineAnimator.ObjectForwardAxis = SplineComponent.AlignAxis.NegativeZAxis;
        }

        //Update the previous recorded time to the current time
        previousTime = time;
    }
}
