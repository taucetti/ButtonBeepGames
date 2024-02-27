using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPosition : MonoBehaviour

   
{
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - startPosition).magnitude > 0.5f)
        {
            transform.position = startPosition;
        }
    }
}
