using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carts : MonoBehaviour
{
    public CartLine carts;
    public CartCollection cartCollection;
    bool stop=false;
   private void OnCollisionEnter(Collision other)
    {
        

        if(cartCollection != null && !carts.isCap &&other.collider.CompareTag("CartsPickUp") && stop != true)
        {
            cartCollection.CartCollected();
            gameObject.SetActive(false);
            Destroy(this.gameObject);
            //stop = true;
        }

    }


}
