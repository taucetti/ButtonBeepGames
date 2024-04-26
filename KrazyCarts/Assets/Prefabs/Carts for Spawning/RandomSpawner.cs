using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] positions; 
    void Start()
    {
        int rand = Random.Range(0, positions.Length);


        this.gameObject.transform.SetPositionAndRotation(positions[rand].gameObject.transform.position, positions[rand].gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
