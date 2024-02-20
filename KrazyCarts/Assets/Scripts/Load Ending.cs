using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnding : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject carts;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.childCount < 1)
        {
            Application.LoadLevel("SampleScene");
        }
    }
}
