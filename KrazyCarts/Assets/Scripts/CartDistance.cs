using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartDistance : MonoBehaviour
{
    public Transform other;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void cartDistance()
    {
        // Script to find the distance between player cart and Player
        // Going to be used to reset carts back in their original position if they move too far
        if(other.tag == "PlayerCarts")
        {
            float dist = Vector3.Distance(other.position, transform.position);
            print("Distance to other: " + dist);

        }
    }
}
