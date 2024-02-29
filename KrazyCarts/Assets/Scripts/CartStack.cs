using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartStack : MonoBehaviour
{
   private GameObject playerCarts;
    // Start is called before the first frame update
   private void Start()
    {
        playerCarts = GameObject.FindWithTag("PlayerCarts");
        playerCarts.SetActive(false);
    }
    
}
