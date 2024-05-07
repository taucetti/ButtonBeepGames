using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAtOrigin : MonoBehaviour
{
    public float minimumDistance;

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.localPosition.x) > minimumDistance ||
            Mathf.Abs(transform.localPosition.z) > minimumDistance)
        {
            transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }
}
