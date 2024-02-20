using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scenes : MonoBehaviour
{
    // Moves to a different Scene
    public void SceneChange(int id){
        SceneManager.LoadScene(id);// When the button's pressed, goes to that scene with the id.
    }                              // Check the Build Setting to see what ID the scene has.
}                                  // EX: If ID set to 0, it'll go to the main menu.
