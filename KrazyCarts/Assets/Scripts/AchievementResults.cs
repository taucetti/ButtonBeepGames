using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AchievementResults : MonoBehaviour
{
    public int movingCars = 0;
    public int parkedCars = 0;
    public int shoppers = 0;
    public Timer time;

    public TextMeshProUGUI movingCarsText;
    public TextMeshProUGUI parkedCarsText;
    public TextMeshProUGUI shoppersText;
    public TextMeshProUGUI timeText;

    public LoadEnding finished;
    // Start is called before the first frame update
    void Start()
    {
        movingCarsText.text = ("");
        parkedCarsText.text = ("");
        shoppersText.text = ("");
        timeText.text = ("");
    }

    // Update is called once per frame
    void Update()
    {
        if (finished.gameWon == true ||  finished.gameLost == true)
        {
            movingCarsText.text = ("Moving Cars Hit: ") + movingCars.ToString();
            //parkedCarsText.text = ("Parked Cars Hit: ") + parkedCars.ToString();
            shoppersText.text = ("Shoppers Hit: ") + shoppers.ToString();
            if (finished.gameLost)
            {
                timeText.text = ("Time Left: 0");
            }
            else
            {
                timeText.text = ("Time Left: ") + Mathf.FloorToInt(time.timeRemaining + 1).ToString();
            }
        }
    }
}
