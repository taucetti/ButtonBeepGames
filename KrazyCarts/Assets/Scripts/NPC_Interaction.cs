using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NPC_Interaction : MonoBehaviour
{
    private AudioSource soundClip;
    public AudioClip greetSound;
    public AudioClip hurtSound;

    private float timeTillHitAgain = 1f;
    private float greetTime = 1f;
    public LoadEnding checker;
    public PauseManager pauseMenu;

    public AchievementResults results;

    // Start is called before the first frame update
    void Start()
    {
        soundClip = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (checker.gameWon != true && checker.gameLost != true && !pauseMenu.isPaused)
        {
            timeTillHitAgain -= Time.deltaTime;
            greetTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if ((other.tag == "Player") && (greetTime < 0))
        {
            soundClip.PlayOneShot(greetSound);
            greetTime = 1f;
        }

        if((other.tag == "PlayerCarts") && (timeTillHitAgain < 0))
        {
            soundClip.PlayOneShot(hurtSound);
            results.shoppers++;
            Paycheck.money = Paycheck.money - 10;
            Debug.Log(results.shoppers);
            timeTillHitAgain = 1f;
        }
    }
}
