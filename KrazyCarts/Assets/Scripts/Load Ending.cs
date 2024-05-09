using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnding : MonoBehaviour
{
    public Timer timer;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject menuButton;
    public GameObject restartButton;
    public GameObject nextButton;
    public GameObject settingsButton;
    public TextMeshProUGUI text;
    public ThirdPersonControllerM controller;
    public bool gameWon;
    public bool gameLost;

    public AudioSource soundClip;
    public AudioSource announceClip;
    public AudioClip winSound;
    public AudioClip lostSound;
    public AudioClip lostQuote1;
    public AudioClip lostQuote2;
    public AudioClip lostQuote3;
    public AudioClip winQuote1;
    public AudioClip winQuote2;
    private int randomNum;

    public CartPickUp cartHold;
    public TotalCarts totalCarts;
    private int check = 0;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        gameWon = false;
        gameLost = false;
        nextButton.SetActive(false);
        settingsButton.SetActive(false);
        randomNum = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Paycheck.money <= -500 && check == 0)
        {
            SceneManager.LoadSceneAsync(12);
            check += 1;
        }

        if (timer.timeRemaining == 0 || ((cartHold.cartHolder >= totalCarts.cartSum) && (Paycheck.money <= 0)))
        {
            gameLost = true;
            Time.timeScale = 0f;
            controller.canMove = false;
            losePanel.SetActive(true);
            text.text = ("Level Failed...");
            text.color = Color.red;
            restartButton.SetActive(true);
            menuButton.SetActive(true);
            settingsButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayLoseClip();
        }
        else if (cartHold.cartHolder >= totalCarts.cartSum)
        {
            gameWon = true;
            Time.timeScale = 0f;
            controller.canMove = false;
            winPanel.SetActive(true);
            text.text = ("Level Completed!");
            restartButton.SetActive(true);
            menuButton.SetActive(true);
            nextButton.SetActive(true);
            settingsButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayWinClip();
        }
        
    }

    public void PlayWinClip()
    {
        if (check == 0)
        {
            soundClip.PlayOneShot(winSound);
            if (randomNum == 1)
            {
                announceClip.PlayOneShot(winQuote1);
            }
            else if (randomNum == 2)
            {
                announceClip.PlayOneShot(winQuote2);
            }
            else
            {
                randomNum = Random.Range(1, 3);
                if (randomNum == 1)
                {
                    announceClip.PlayOneShot(winQuote1);
                }
                else if (randomNum == 2)
                {
                    announceClip.PlayOneShot(winQuote2);
                }
            }
            check += 1;
        }
    }
    public void PlayLoseClip()
    {
        if (check == 0)
        {
            soundClip.PlayOneShot(lostSound);

            if (randomNum == 1)
            {
                announceClip.PlayOneShot(lostQuote1);
            }
            else if (randomNum == 2)
            {
                announceClip.PlayOneShot(lostQuote2);
            }
            else if (randomNum == 3)
            {
                announceClip.PlayOneShot(lostQuote3);
            }
            check += 1;
        }
    }
}
