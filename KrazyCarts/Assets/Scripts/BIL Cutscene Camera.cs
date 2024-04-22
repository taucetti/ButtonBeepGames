using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class BILCutsceneCamera : MonoBehaviour
{
   
    VideoPlayer video;

        void Awake()
        {
            video = GetComponent<VideoPlayer>();
            video.Play();
            video.loopPointReached += CheckOver;
            GameObject camera = GameObject.Find("Main Camera");


    }


        void CheckOver(UnityEngine.Video.VideoPlayer vp)
        {
            SceneManager.LoadScene(3);//the scene that you want to load after the video has ended.
        }
    }