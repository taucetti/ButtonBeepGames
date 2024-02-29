using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartLine : MonoBehaviour
{
    public GameObject[] playerCarts;

    void Awake ()
    {
        playerCarts = GameObject.FindGameObjectsWithTag("PlayerCarts");
    

    }
    void OnTriggerEnter(Collider cart)
    {
   
        if (cart.CompareTag("Cart"))
        {

            for (int i = 0; i < playerCarts.Length;i++)
            {
                playerCarts[i].SetActive(true);
               
            }

        }
        //    if (other.CompareTag("Goal"))
        //    {

        //    }
    }
}
