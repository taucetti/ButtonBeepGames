using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// This is mostly the same script, except without anything to stop it

public class MP3_Free : MonoBehaviour
{
    public AudioClip[] musicClips; // Array to hold all music clips
    private AudioSource source;
    private int currentTrack; // Index of the current music track

    public TextMeshProUGUI musicTitle;
    public TextMeshProUGUI musicTimer;

    private int fullLength;
    private int playTime;
    private int seconds;
    private int minutes;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        // Play Music when starting level.
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for user input to switch to the next music track
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextMusic();
        }

        // Check for user input to switch to the previous music track
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PreviousMusic();
        }

        // Check for user input to stop/play the music
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (source.isPlaying)
            {
                StopMusic();
            }
            else
            {
                PlayMusic();
            }
        }
    }

    public void PlayMusic()
    {
        // Check if music is already playing
        if (source.isPlaying)
        {
            return;
        }

        // Move to the previous music track
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicClips.Length - 1;
        }



        // Start playing the music
        StartCoroutine("WaitForMusicEnd");
    }

    // Coroutine to wait for the music clip to end
    IEnumerator WaitForMusicEnd()
    {
        while (source.isPlaying)
        {
            playTime = (int)source.time;
            ShowPlayTime();
            yield return null;
        }
        NextMusic();
    }

    // Function to play the next music track
    public void NextMusic()
    {
        source.Stop(); // Stop the current music

        // Move to the next music track
        currentTrack++;
        if (currentTrack > musicClips.Length - 1)
        {
            currentTrack = 0;
        }

        // Set the new music clip and start playing
        source.clip = musicClips[currentTrack];
        source.Play();

        // Show Title
        ShowCurrentMusic();

        // Start waiting for music to end again
        StartCoroutine("WaitForMusicEnd");
    }

    // Function to play the previous music track
    public void PreviousMusic()
    {
        source.Stop(); // Stop the current music

        // Move to the previous music track
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = musicClips.Length - 1;
        }

        // Set the new music clip and start playing
        source.clip = musicClips[currentTrack];
        source.Play();

        // Show Title
        ShowCurrentMusic();

        // Start waiting for music to end again
        StartCoroutine("WaitForMusicEnd");
    }

    // Function to stop and reset the music to starting time.
    public void StopMusic()
    {
        StopCoroutine("WaitForMusicEnd"); // Stop waiting for the music to end
        source.Stop(); // Stop the music playback

        musicTimer.text = "0:00 / " + ((fullLength / 60) % 60) + ":" + (fullLength % 60).ToString("D2");
    }

    // Function to display the title of the current music track
    void ShowCurrentMusic()
    {
        musicTitle.text = source.clip.name.ToLower(); // Display the name of the current music clip
        fullLength = (int)source.clip.length; // Get the length of the current music clip in seconds
    }

    // Function to display the current playback time of the music
    void ShowPlayTime()
    {
        // Calculate minutes and seconds from the current playback time
        seconds = playTime % 60;
        minutes = (playTime / 60) % 60;

        // Display the current playback time and total length of the music clip
        musicTimer.text = minutes + ":" + seconds.ToString("D2")
            + " / " + ((fullLength / 60) % 60) + ":" + (fullLength % 60).ToString("D2");
    }
}
