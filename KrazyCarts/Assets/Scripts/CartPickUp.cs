using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPickUp : MonoBehaviour
{
    public CartLine cartLine;
    bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    
    private void OnCollisionEnter(Collision other)
    {
        

        if (other.collider.CompareTag("Cart") && stop != true)
        {
            cartLine._PlayerCarts[cartLine.cartCount].SetActive(true);
            cartLine.cartCount++;
            stop = true;
        }
        

    }
}
