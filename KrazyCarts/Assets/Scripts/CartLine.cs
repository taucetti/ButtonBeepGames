using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartLine : MonoBehaviour
{
    public GameObject[] playerCarts;
    [SerializeField] GameObject _Controller;
    [SerializeField] GameObject[] _PlayerCarts;

    void Start ()
    {
        GameObject[] _PlayerCarts = GameObject.FindGameObjectsWithTag("PlayerCarts");
        foreach (GameObject go in _PlayerCarts)
        {
            go.SetActive(false);
        }


    }
    void OnTriggerEnter(Collider cart)
    {
   
        if (cart.CompareTag("Cart"))
        {

            for (int i = 0; i < playerCarts.Length;i++)
            {
                _PlayerCarts[i].SetActive(true);
 
            }

        }
        //    if (other.CompareTag("Goal"))
        //    {

        //    }
    }
}
