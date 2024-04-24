using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapImage : MonoBehaviour
{
    private Image _imageDisplayer;
    public Sprite _frameOne, _frameTwo;
    private bool _isStartingFrame;

    private float _timeToSwap;
    public float _secondsBetweenFrames;

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
        if (_timeToSwap > 0f)
        {
            //Decrease the time to swap image is there is time left
            _timeToSwap -= Time.deltaTime;

            //If the timer goes below zero, swap the image, then reset the timer
            if (_timeToSwap <= 0)
            {
                Swap();
                _timeToSwap = _secondsBetweenFrames;
            }
        }
    }

    void Swap()
    {
        if (_isStartingFrame)
        {
            _imageDisplayer.sprite = _frameOne;
            _isStartingFrame = false;
        }
        else
        {
            _imageDisplayer.sprite = _frameTwo;
            _isStartingFrame = true;
        }
    }
}
