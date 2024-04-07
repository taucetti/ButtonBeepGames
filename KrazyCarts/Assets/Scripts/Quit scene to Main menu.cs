using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitscenetoMainmenu : MonoBehaviour
{

    public void ReturntoMM()
    {
        SceneManager.LoadSceneAsync(0);
    }
   
}
