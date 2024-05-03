using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpeedCheat speedManager = other.gameObject.GetComponent<SpeedCheat>();
            if (speedManager)
            {
                speedManager.IncreaseSpeed();
                gameObject.SetActive(false);
            }
        }
    }
}
