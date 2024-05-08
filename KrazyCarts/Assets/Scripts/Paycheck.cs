using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paycheck : MonoBehaviour
{
    public static int money = 120;
    public static bool isRestarted = false;
    private static int originalCheck = 0;
    public TextMeshProUGUI text;
    private Coroutine flashCoroutine = null;
    private float flashDuration = 0.5f; // duration of the flash in seconds
    private int lastCheck = 0;

    void Update()
    {
        text.text = ("Paycheck: $" + money);

        // Check for change in money since last frame
        if (money != lastCheck)
        {
            if (flashCoroutine != null)
            {
                StopCoroutine(flashCoroutine);
            }

            if (money > lastCheck)
            {
                flashCoroutine = StartCoroutine(FlashText(Color.green));
            }
            else if (money < lastCheck)
            {
                flashCoroutine = StartCoroutine(FlashText(Color.red));
            }

            lastCheck = money; // Update the last check
        }
    }
    void Start()
    { 
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            money = 120;
        }

        else if (isRestarted || SceneManager.GetActiveScene().buildIndex == 11)
        {
            money = originalCheck;
            isRestarted = false;
        }
        originalCheck = money;
        lastCheck = money;
    }

    IEnumerator FlashText(Color flashColor)
    {
        Color originalColor = Color.white; // Store the original color
        text.color = flashColor; // Set to the flash color

        yield return new WaitForSeconds(flashDuration); // Wait for the flash duration

        if (money <= 0)
        {
            text.color = Color.red; // Change red if paycheck is 0 or less
        }
        else
        {
            text.color = originalColor; // Reset to the original color
        }
    }
}
