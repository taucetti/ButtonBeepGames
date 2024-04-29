using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCheat : MonoBehaviour
{
    private ThirdPersonControllerM player;

    void Start()
    {
        player = GetComponent<ThirdPersonControllerM>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player press 1, they will get a speed boost, but has a speed limit
        // and speed can still be reseted after depositing carts.
        if ((Input.GetKeyDown("1")) && (player.walkingSpeed < 50))
        {
            player.walkingSpeed *= 1.5f;
            player.runningSpeed *= 1.5f;
        }
    }
}
