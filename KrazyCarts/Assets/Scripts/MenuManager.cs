using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1); // script will load our main scene for our game but I have to as test scene for now
    }

    public void QuitGame()
    {
        Application.Quit(); // script will quit our game with on click button function
    }

    public void SettingsButton()
    {
        SceneManager.LoadSceneAsync(2); // this will load our settings screen
    }

    public void CreditsButton()
    {
        SceneManager.LoadSceneAsync(3); // this will load our credits screen
    }

    public void MenusButton()
    {
        SceneManager.LoadSceneAsync(0); // this script will send you to the main menu can be used as a back or menus button
    }
}
