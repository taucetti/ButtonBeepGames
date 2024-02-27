using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

/*
    Place this script on the object containing the carts
    and it'll automatically count the total carts in the object.
 */
public class TotalCarts : MonoBehaviour
{
    public int cartSum;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] carts = GameObject.FindGameObjectsWithTag("Cart");
        cartSum = carts.Length;
        Debug.Log(carts.Length);
    }
}
