using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartLevel(){
        if(SceneManager.GetActiveScene().buildIndex != 3)
        {
            Paycheck.isRestarted = true;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
