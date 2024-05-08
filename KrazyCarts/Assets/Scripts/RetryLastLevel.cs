using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLastLevel : MonoBehaviour
{
    public AudioSource soundClip;
    public AudioSource soundClip2;
    public AudioClip lostSound;
    public AudioClip lostQuote1;
    public AudioClip lostQuote2;
    public AudioClip lostQuote3;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        soundClip.PlayOneShot(lostSound);

        int randomNum = Random.Range(1, 4);
        if (randomNum == 1)
        {
            soundClip2.PlayOneShot(lostQuote1);
        }
        else if (randomNum == 2)
        {
            soundClip2.PlayOneShot(lostQuote2);
        }
        else if (randomNum == 3)
        {
            soundClip2.PlayOneShot(lostQuote3);
        }
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync(LastActiveScene.buildID);
    }
}
