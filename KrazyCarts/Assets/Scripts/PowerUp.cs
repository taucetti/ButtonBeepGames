using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public AudioSource soundClip;
    public AudioClip soundEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpeedCheat speedManager = other.gameObject.GetComponent<SpeedCheat>();
            if (speedManager)
            {
                soundClip.PlayOneShot(soundEffect);
                speedManager.IncreaseSpeed();
                gameObject.SetActive(false);
            }
        }
    }
}
