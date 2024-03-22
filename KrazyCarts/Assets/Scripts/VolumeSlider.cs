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
    public Slider volumeSlider;

    public void SetVolume(float volume)   // created a function name set volume this will be the name that shows up in unity
    {
        //If the volume slider is at its minimum value, set the audio mixer to -80 db to properly mute the volume
        if (volume == volumeSlider.minValue)
        {
            mixer.SetFloat("Master", -80);
        }
        else
        {
            mixer.SetFloat("Volume", volume);   // this will reference for my audio mixer
        }
    }

    public void LowGraphics () // below sets all the graphics to what the player chooses it references "Quality" in unity project settings
    {
        QualitySettings.SetQualityLevel(0); // sets the graphics to low
    }

    public void MediumGraphics ()
    {
        QualitySettings.SetQualityLevel(1); // sets the graphics to medium
    }

    public void HighGraphics ()
    {
        QualitySettings.SetQualityLevel(2); // sets the graphics to high
    }

}
