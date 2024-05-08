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
        SceneManager.LoadSceneAsync(7); // script will load our main scene for our game
    }

    public void QuitGame()
    {
        Application.Quit(); // script will quit our game with on click button
    }

    public void SettingsButton()
    {
        SceneManager.LoadSceneAsync(1); // this will load our settings screen
    }

    public void SettingsButtonPortable()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void CreditsButton()
    {
        SceneManager.LoadSceneAsync(10); // this will load our credits screen
    }

    public void MenusButton()
    {
        SceneManager.LoadSceneAsync(0); // this script will send you to the main menu can be used as a back or menus button
    }

    public void Level2Button () // this script will send you to Level 2 intro cutscene
    {
        SceneManager.LoadSceneAsync(9);
    }

    public void Level3Button ()
    {
        SceneManager.LoadSceneAsync(8);
    }

    public void LevelSelectionButton () // this script will send you to Level Selection Screen
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void BackToPause()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
