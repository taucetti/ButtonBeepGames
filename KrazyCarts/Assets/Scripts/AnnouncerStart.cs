using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncerStart : MonoBehaviour
{
    private AudioSource audioSource;
    private static bool played = false;

    // This method is called when the script instance is being loaded
    void Start()
    {
        // Get the AudioSource component from the GameObject
        audioSource = GetComponent<AudioSource>();

        // If an AudioSource is attached and there's a clip assigned, play the sound
        if (audioSource != null && audioSource.clip != null && played == false)
        {
            audioSource.Play();
            played = true;
        }
    }
}
