using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AchievementResults : MonoBehaviour
{
    public int cars = 0;
    public int shoppers = 0;
    public Timer time;

    public TextMeshProUGUI carsText;
    public TextMeshProUGUI currentCashText;
    public TextMeshProUGUI shoppersText;
    public TextMeshProUGUI timeText;

    public LoadEnding finished;
    // Start is called before the first frame update
    void Start()
    {
        carsText.text = ("");
        currentCashText.text = ("");
        shoppersText.text = ("");
        timeText.text = ("");
    }

    // Update is called once per frame
    void Update()
    {
        if (finished.gameWon == true ||  finished.gameLost == true)
        {
            carsText.text = ("Cars Hit: ") + cars.ToString();
            currentCashText.text = ("Current Paycheck: \n$ ") + Paycheck.money.ToString();
            shoppersText.text = ("Shoppers Hit: ") + shoppers.ToString();
            timeText.text = ("Time Left: ") + Mathf.FloorToInt(time.timeRemaining).ToString();
        }
    }
}
