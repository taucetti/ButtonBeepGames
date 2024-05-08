using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastActiveScene : MonoBehaviour
{

    public static int buildID;

    void Start()
    {
        buildID = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(buildID);
    }
}
