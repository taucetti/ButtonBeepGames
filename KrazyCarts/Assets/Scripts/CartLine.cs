using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartLine : MonoBehaviour
{
 
    public GameObject _Controller;
    public GameObject[] _PlayerCarts;
    public int cartCount;
    public int cartHolder;

    public AudioSource soundClip;
    public AudioClip soundEffect;
    public bool isCap;
    public GameObject message;

    void Awake ()
    {
        //Find all GameObjects with Tag Player Carts and set them inactive
        GameObject[] _PlayerCarts = GameObject.FindGameObjectsWithTag("PlayerCarts");
        foreach (GameObject go in _PlayerCarts)
        {
            go.SetActive(false);
        }
        // cartCount Variable Declaration
        cartCount = 0;
        isCap = false;
        message.SetActive(false);

    }
    void OnTriggerEnter(Collider cart)
    {
        // If Player Controller collides with cart run the cartCount comparison
        if (cart.CompareTag("Cart"))
        {
            Debug.Log("pickupCart");

            if(cartCount > _PlayerCarts.Length - 1)
            {
                cartCount = _PlayerCarts.Length - 1;
            }
            // Loop to set a single cart active when trigger is entered
            _PlayerCarts[cartCount].SetActive(true);
            cartCount++;

            if(cartCount == _PlayerCarts.Length)
            {
                isCap = true;
                Debug.Log("Full");
                message.SetActive(true);
            }

        }   

        if (cart.CompareTag("Finish"))
        {
            if(cartCount > 0)
            {
                for(int i = 0; i < cartCount; i++)
                {
                    Debug.Log("ByeCart");
                    _PlayerCarts[i].SetActive(false);
                    cartHolder++;
                }
                if (cartCount == _PlayerCarts.Length)
                {
                    isCap = false;
                    Debug.Log("No longer full");
                    message.SetActive(false);
                }
                cartCount = 0;
                soundClip.PlayOneShot(soundEffect);

            }
        }
    }
}
