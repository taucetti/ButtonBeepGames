using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NPC_Interaction : MonoBehaviour
{
    private AudioSource soundClip;
    public AudioClip greetSound;
    public AudioClip hurtSound;

    public AchievementResults results;

    // Start is called before the first frame update
    void Start()
    {
        soundClip = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            soundClip.PlayOneShot(greetSound);
        }

        if(other.tag == "PlayerCarts")
        {
            soundClip.PlayOneShot(hurtSound);
            results.shoppers++;
            Paycheck.money = Paycheck.money - 10;
            Debug.Log(results.shoppers);
        }
    }
}
