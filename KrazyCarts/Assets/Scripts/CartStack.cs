using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartStack : MonoBehaviour
{
   public GameObject playerCarts;
    // Start is called before the first frame update
    void Awake()
    {
        playerCarts = GameObject.FindWithTag("PlayerCarts");
        playerCarts.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       
        CartCollection cartCollection = other.GetComponent<CartCollection>();
      
        if (cartCollection != null)
        {
            cartCollection.CartCollected();
            
        }
        if(cartCollection.NumberOfCarts < 0)
        {
            playerCarts.SetActive(true);
        }

    }
}
