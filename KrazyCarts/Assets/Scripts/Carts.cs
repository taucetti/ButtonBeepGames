using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carts : MonoBehaviour
{
    public CartLine carts;
   private void OnTriggerEnter(Collider other)
    {
        CartCollection cartCollection = other.GetComponent<CartCollection>();

        if(cartCollection != null && !carts.isCap)
        {
            cartCollection.CartCollected();
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

    }


}
