using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
  
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(3); // script will load our main scene for our game
    }

    public void QuitGame()
    {
        Application.Quit(); // script will quit our game with on click button
        Application.OpenURL("https://forms.gle/63XfdquGYCrWJwwD9");
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
        SceneManager.LoadSceneAsync(2); // this will load our credits screen
    }

    public void MenusButton()
    {
        SceneManager.LoadSceneAsync(0); // this script will send you to the main menu can be used as a back or menus button
    }

    public void Level2Button () // this script will send you to Level 2
    {
        SceneManager.LoadSceneAsync(4);
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
