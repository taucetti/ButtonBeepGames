using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    public AudioClip winSound;
    public AudioClip lostSound;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (cartHold.cartHolder >= totalCarts.cartSum)
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
        else if(timer.timeRemaining == 0)
        {
            gameLost = true;
            Time.timeScale = 0f;
            controller.canMove = false;
            losePanel.SetActive(true);
            text.text = ("Level Failed...");
            restartButton.SetActive(true);
            menuButton.SetActive(true);
            settingsButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayLoseClip();
        }
    }

    public void PlayWinClip()
    {
        if (check == 0)
        {
            soundClip.PlayOneShot(winSound);
            check += 1;
        }
    }
    public void PlayLoseClip()
    {
        if (check == 0)
        {
            soundClip.PlayOneShot(lostSound);
            check += 1;
        }
    }
}
