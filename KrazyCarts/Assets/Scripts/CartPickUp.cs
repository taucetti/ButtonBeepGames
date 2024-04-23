using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPickUp : MonoBehaviour
{
    public GameObject[] _PlayerCarts;
    public int cartCount;
    public int cartHolder;

    public AudioSource soundClip;
    public AudioClip soundEffect;
    public bool isCap;
    public GameObject message;

    public ThirdPersonControllerM ws;

    BoxCollider m_Collider;
    float m_ScaleX, m_ScaleY, m_ScaleZ;

    // Start is called before the first frame update
    void Awake()
    {
        //To get your hinges to actually move, you'd need space and for these to not be confined in a collider for
        //best results. I'd suggest putting separate colliders on each cart.

        m_Collider = GetComponent<BoxCollider>();
        m_ScaleX = 1;
        m_ScaleY = 1;
        m_ScaleZ = 1;
        //Find all GameObjects with Tag Player Carts and set them inactive
        //WARNING. This DOES NOT FIND CHILDREN OBJECTS.
        //If this isn't explicitly accessed anywhere, you could just Serialize it, make it private and drag them into the inspector.
        //Or just drag them in the inspector, instead of using the Find method. It's less taxing on the system.
        GameObject[] _PlayerCarts = GameObject.FindGameObjectsWithTag("PlayerCarts");
        foreach (GameObject go in _PlayerCarts)
        {
            go.SetActive(false);
        }
        // cartCount Variable Declaration
        cartCount = 0;
        isCap = false;
        message.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Cart"))
        {
            Debug.Log("Touched");
            if (cartCount != _PlayerCarts.Length)
            {

                _PlayerCarts[cartCount].SetActive(true);
                if (cartCount > 0)
                {
                    //add the hinge joint in connecting it to the previous cart.
                    _PlayerCarts[cartCount].GetComponent<HingeJoint>().connectedBody = _PlayerCarts[cartCount - 1].GetComponent<Rigidbody>(); ;
                }
                cartCount++;
            }
            ws.walkingSpeed *= 0.9f;
            ws.runningSpeed *= 0.9f;

            m_ScaleZ += 3;

            m_Collider.size = new Vector3(m_ScaleX, m_ScaleY, m_ScaleZ);

            if (cartCount == _PlayerCarts.Length)
            {
                isCap = true;
                message.SetActive(true);
            }
        }
    }
}
