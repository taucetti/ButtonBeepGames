using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MP3 : MonoBehaviour
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

    private bool putAway;
    private float timeToPutAway = 5f;

    public LoadEnding checker;
    public PauseManager pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        ShuffleTracks();
        // Play Music when starting level.
        PlayMusic();
        putAway = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (checker.gameWon != true && checker.gameLost != true && !pauseMenu.isPaused)
        {
            timeToPutAway -= Time.deltaTime;
            // Check for user input to switch to the next music track
            if (Input.GetKeyDown(KeyCode.E))
            {
                timeToPutAway = 5f;
                NextMusic();
                ShowIt();
            }

            // Check for user input to switch to the previous music track
            if (Input.GetKeyDown(KeyCode.Q))
            {
                timeToPutAway = 5f;
                PreviousMusic();
                ShowIt();
            }

            // Check for user input to stop/play the music
            if (Input.GetKeyDown(KeyCode.P))
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

            if (putAway == false && timeToPutAway <= 0)
            {
                transform.LeanMoveLocal(new Vector2(750, -760), 1).setEaseInOutBack();
                putAway = true;
            }
        }

        // Stops the music when the level's finished
        if(checker.gameWon == true || checker.gameLost == true)
        {
            StopMusic();
        }
    }

    // Function to shuffle the tracks in the list
    public void ShuffleTracks()
    {
        for (int i = 0; i < musicClips.Length; i++)
        {
            AudioClip tempClip = musicClips[i];
            int randomIndex = Random.Range(i, musicClips.Length);
            musicClips[i] = musicClips[randomIndex];
            musicClips[randomIndex] = tempClip;
        }
    }

    // Function to play the music
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
        while(source.isPlaying)
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
        if(currentTrack > musicClips.Length - 1)
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
        musicTitle.text = source.clip.name; // Display the name of the current music clip
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

    void ShowIt()
    {
        if(putAway == true)
        {
            transform.LeanMoveLocal(new Vector2(750, -500), 1).setEaseInOutBack();
            putAway = false;
        }
    }
}
