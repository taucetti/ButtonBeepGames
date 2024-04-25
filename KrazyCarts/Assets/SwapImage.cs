using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapImage : MonoBehaviour
{
    public Sprite _frameOne, _frameTwo;     //The two frames of the animation   
    public float _secondsBetweenFrames;     //The amount of seconds between swapping frames

    private Image _imageDisplayer;
    private bool _isStartingFrame;  //Whether the currently displayed frame is the default frame. Used to determine which frame to swap to.
    private float _timeToSwap;      //The timer used to count down time between frames

    // Start is called before the first frame update
    void Start()
    {
        _imageDisplayer = GetComponent<Image>();
        _imageDisplayer.sprite = _frameOne;
        _isStartingFrame = true;
        _timeToSwap = _secondsBetweenFrames;
    }

    // Update is called once per frame
    void Update()
    {
        //Decrease the time to swap image while there is time left
        _timeToSwap -= Time.deltaTime;

        //If the timer goes below zero, swap the image, then reset the timer
        if (_timeToSwap <= 0)
        {
            Swap();
            _timeToSwap = _secondsBetweenFrames;
        }
    }

    void Swap()
    {
        //If the starting frame is being displayed, swap to the other frame
        if (_isStartingFrame)
        {
            _imageDisplayer.sprite = _frameTwo;
            _isStartingFrame = false;
        }
        //If the other frame is being displayed, swap to the starting frame
        else
        {
            _imageDisplayer.sprite = _frameOne;
            _isStartingFrame = true;
        }
    }
}
