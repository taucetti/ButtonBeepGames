using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{   // variables: length of bg and its start position, camera, and parallax
    // Start of an effect, needs to be modified for 3D purposes 
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

  
    void Start()
    {   // Gets the starting location (x) and length of bg
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }


    void FixedUpdate()
    {   // These will determine the distance the camera (player) has moved
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        // How background repeats based on start position and distance moved
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos + length) startpos -= length;
    }
}
