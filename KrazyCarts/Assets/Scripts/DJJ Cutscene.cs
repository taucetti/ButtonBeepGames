using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DJJCutscene : MonoBehaviour
{
    public AudioSource cutsceneAudio;

    public void TransitionToNextScene(int nextScene)
    {
        cutsceneAudio.Pause();
        SceneManager.LoadScene(nextScene);//the scene that you want to load after the video has ended.
    }
}
