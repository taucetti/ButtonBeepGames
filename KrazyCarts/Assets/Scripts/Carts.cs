using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carts : MonoBehaviour
{
    public CartPickUp carts;
    public CartCollection cartCollection;
   private void OnCollisionEnter(Collision other)
    {
        

        if(cartCollection != null && !carts.isCap && other.collider.CompareTag("CartsPickUp"))
        {
            cartCollection.CartCollected();
            gameObject.SetActive(false);
            Destroy(this.gameObject);
            //stop = true;
        }

    }


}
