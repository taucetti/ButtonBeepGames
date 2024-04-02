using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NPC_Interaction : MonoBehaviour
{
    private AudioSource soundClip;
    public AudioClip greetSound;

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

    }
}
