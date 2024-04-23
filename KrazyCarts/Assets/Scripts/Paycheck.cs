using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paycheck : MonoBehaviour
{
    public static int money = 120;
    public static bool isRestarted = false;
    private static int lastCheck = 0;
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = ("Paycheck: $" + money);
    }
    void Start()
    { 
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            money = 120;
        }
        else if (isRestarted)
        {
            money = lastCheck;
            isRestarted = false;
        }
        lastCheck = money;
    }
}
