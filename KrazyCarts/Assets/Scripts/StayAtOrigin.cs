using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAtOrigin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!Mathf.Approximately(transform.localPosition.x, 0f) ||
            !Mathf.Approximately(transform.localPosition.z, 0f))
        {
            transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }
}
