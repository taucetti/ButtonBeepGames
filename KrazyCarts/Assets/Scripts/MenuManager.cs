using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [Tooltip("The canvas containing the pause menu. Only necessary if making use of the portable settings menu.")]
    public GameObject pauseMenu;
    [Tooltip("The portable settings menu prefab. Only necessary if making use of the portable settings menu.")]
    public GameObject settingsMenu;
  
    public void PlayGame()
    {
        //Redirect to the cutscene before loading the first level
        SceneManager.LoadSceneAsync(8); // script will load our main scene for our game
    }

    public void QuitGame()
    {
        Application.Quit(); // script will quit our game with on click button
    }

    public void SettingsButton()
    {
        SceneManager.LoadSceneAsync(2); // this will load our settings screen
    }

    public void SettingsButtonPortable()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void CreditsButton()
    {
        SceneManager.LoadSceneAsync(11); // this will load our credits screen
    }

    public void MenusButton()
    {
        SceneManager.LoadSceneAsync(1); // this script will send you to the main menu can be used as a back or menus button
    }

    public void Level2Button () // this script will send you to Level 2 intro cutscene
    {
        SceneManager.LoadSceneAsync(10);
    }

    public void Level3Button ()
    {
        SceneManager.LoadSceneAsync(16);
    }

    public void LevelSelectionButton () // this script will send you to Level Selection Screen
    {
        SceneManager.LoadSceneAsync(6);
    }

    public void MP3_Button()
    {
        SceneManager.LoadSceneAsync(13);
    }

    public void BackToPause()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
