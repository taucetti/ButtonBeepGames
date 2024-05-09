using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class AfterBILcutscene : MonoBehaviour
{
    VideoPlayer video;
    //public AudioSource cutsceneAudio;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
        GameObject camera = GameObject.Find("Main Camera");
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        TransitionToNextScene();
    }

    public void TransitionToNextScene()
    {
        //cutsceneAudio.Pause();
        SceneManager.LoadScene(10);//the scene that you want to load after the video has ended.
    }
}
