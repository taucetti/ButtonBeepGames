using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyaway : MonoBehaviour
{
    Animator animate;
    public float delay = 5f;// Depending on how long the animation is, change the delay time before destroying itself.
    // Start is called before the first frame update
    void Start()
    {
        animate = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            animate.SetBool("isFlying", true);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
            // Allows the object to animate upon player getting close enough, then destroy itself after awhile.
        }
    }

}
