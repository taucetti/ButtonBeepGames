using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paycheck : MonoBehaviour
{
    public static int money = 500;
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = ("Paycheck: $" + money);
    }
    void Start()
    { 
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            money = 500;
        }
    }
}
