using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float _degreesPerSecond;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + _degreesPerSecond * Time.deltaTime);
    }
}
