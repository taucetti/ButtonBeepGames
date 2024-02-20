using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carts : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        CartCollection cartCollection = other.GetComponent<CartCollection>();

        if(cartCollection != null)
        {
            cartCollection.CartCollected();
            gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision otherObj)
    {
        if(otherObj.gameObject.tag == "Cart")
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
