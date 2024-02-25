using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHorn : MonoBehaviour
{
    private AudioSource soundClip;
    public AudioClip soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        soundClip = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            soundClip.PlayOneShot(soundEffect);
        }

    }

}
