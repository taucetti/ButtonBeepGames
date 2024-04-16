using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPickUp : MonoBehaviour
{
    public CartLine cartLine;
    bool stop = false;

    BoxCollider m_Collider;
    float m_ScaleX, m_ScaleY, m_ScaleZ;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
        m_ScaleX = 1;
        m_ScaleY = 1;
        m_ScaleZ = 1;

    }

    // Update is called once per frame
    
    private void OnCollisionEnter(Collision other)
    {
        

        if (other.collider.CompareTag("Cart"))
        {
            cartLine._PlayerCarts[cartLine.cartCount].SetActive(true);
            
            cartLine.cartCount++;
            stop = true;
            m_ScaleZ += 3;

            m_Collider.size = new Vector3(m_ScaleX, m_ScaleY, m_ScaleZ);
            
        }
        if(stop == true)
        {
            Debug.Log("The Script is working");
        }
        

    }
}
