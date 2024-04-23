using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class CartGoal : MonoBehaviour
{
    public CartPickUp carts;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            if (carts.cartCount > 0)
            {
                for (int i = 0; i < carts.cartCount; i++)
                {
                    carts._PlayerCarts[i].SetActive(false);
                    carts.cartHolder++;
                    Paycheck.money = Paycheck.money + 5;
                }
                if (carts.isCap == true)
                {
                    carts.isCap = false;
                    carts.message.SetActive(false);
                }
                // Set the movement back to default when the carts are returned
                carts.ws.walkingSpeed = 7.5f;
                carts.ws.runningSpeed = 11.5f;

                carts.cartCount = 0;
                carts.soundClip.PlayOneShot(carts.soundEffect);
            }
        }
    }
}
