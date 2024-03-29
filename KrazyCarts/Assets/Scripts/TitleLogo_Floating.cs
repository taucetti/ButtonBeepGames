using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLogo_Floating : MonoBehaviour
{
    // Makes the Title float.
    void Start()
    {
        transform.LeanMoveLocal(new Vector2(0, 270), 2).setEaseInOutSine().setLoopPingPong();
    }
}
