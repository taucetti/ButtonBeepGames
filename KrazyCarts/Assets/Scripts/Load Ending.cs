using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnding : MonoBehaviour
{
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < 1)
        {
            Application.LoadLevel("Win");
        }
        else if(timer.timeRemaining == 0)
        {
            Application.LoadLevel("SampleScene");
        }
    }
}
