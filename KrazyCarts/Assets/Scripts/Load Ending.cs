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
    public TextMeshProUGUI text;
    public ThirdPersonControllerM controller;
    public bool gameWon;
    public bool gameLost;
    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        gameWon = false;
        gameLost = false;
        nextButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < 1)
        {
            gameWon = true;
            Time.timeScale = 0f;
            controller.canMove = false;
            winPanel.SetActive(true);
            text.text = ("Level Completed!");
            restartButton.SetActive(true);
            menuButton.SetActive(true);
            nextButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
