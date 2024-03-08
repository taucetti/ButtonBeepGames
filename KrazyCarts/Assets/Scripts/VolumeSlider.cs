using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

// created by Nikolas script for volume slider


public class VolumeSlider : MonoBehaviour
{
    public float volume;   
    public AudioMixer mixer;

    public void SetVolume(float volume)   // created a function name set volume this will be the name that shows up in unity
    {
        mixer.SetFloat("Volume", volume);   // this will reference for my audio mixer
    }

    public void LowGraphics ()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void MediumGraphics ()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void HighGraphics ()
    {
        QualitySettings.SetQualityLevel(2);
    }

}
