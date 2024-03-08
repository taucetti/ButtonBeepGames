using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartLine : MonoBehaviour
{
 
    [SerializeField] GameObject _Controller;
    [SerializeField] GameObject[] _PlayerCarts;
    [SerializeField] int cartCount;

    void Start ()
    {
        //Find all GameObjects with Tag Player Carts and set them inactive
        GameObject[] _PlayerCarts = GameObject.FindGameObjectsWithTag("PlayerCarts");
        foreach (GameObject go in _PlayerCarts)
        {
            go.SetActive(false);
        }
        // cartCount Variable Declaration
        cartCount = 0;


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




        }   
          /*  for (int i = 0; i < _PlayerCarts.Length;i++)
            {
                _PlayerCarts[i].SetActive(true);
 
            }

        }
          */
        //    if (other.CompareTag("Goal"))
        //    {

        //    }
    }
}
