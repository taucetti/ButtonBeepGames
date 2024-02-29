using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartLine : MonoBehaviour
{
    public GameObject[] playerCarts;

    void Start ()
    {
        playerCarts = GameObject.FindGameObjectsWithTag("PlayerCarts");

    }
    void OnTriggerEnter(Collider other)
    {
   
        if (other.CompareTag("Cart"))
        {

            for (int i = 0; i < playerCarts.Length; i++)
            {
                playerCarts.GameObject.SetActive(true);
            }

        }
        //    if (other.CompareTag("Goal"))
        //    {

        //    }
    }
}
