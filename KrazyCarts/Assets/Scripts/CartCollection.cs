using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CartCollection : MonoBehaviour
{
    public int NumberOfCarts { get; private set; }
    public AudioSource soundClip;
    public AudioClip soundEffect;

    public UnityEvent<CartCollection> OnCartCollected;
    public void CartCollected()
    {
        soundClip.PlayOneShot(soundEffect);
        OnCartCollected.Invoke(this);
    }
}
