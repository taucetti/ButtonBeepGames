using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class StopForPedestrian : MonoBehaviour
{
    SplineAnimate splineAnimator;

    // Start is called before the first frame update
    void Start()
    {
        splineAnimator = GetComponent<SplineAnimate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            splineAnimator.Pause();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            splineAnimator.Play();
        }
    }
}
