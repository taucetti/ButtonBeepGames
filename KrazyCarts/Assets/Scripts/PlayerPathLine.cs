using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //how we get navmesh

public class PlayerPathLine : MonoBehaviour
{
    //where we want to go
    [SerializeField]
    private Transform goal;

    //where we are
    [SerializeField]
    private Transform plyr;

    //what's gonna guide us
    [SerializeField]
    private LineRenderer line;



    private void Update()
    {
        line.SetPosition(0, plyr.position);
        line.SetPosition(1, goal.position);
    }

    
}
