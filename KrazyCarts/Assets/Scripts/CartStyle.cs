using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartStyle : MonoBehaviour
{
    public enum Style { None, BIL, Juicy, Nacho };

    public Style cartStyle;

    public GameObject bilCart;
    public GameObject juicyCart;
    public GameObject nachoCart;

    // Start is called before the first frame update
    void Start()
    {
        bilCart.SetActive(false);
        juicyCart.SetActive(false);
        nachoCart.SetActive(false);

        switch (cartStyle)
        {
            case Style.BIL:
                bilCart.SetActive(true);
                break;
            case Style.Juicy:
                juicyCart.SetActive(true);
                break;
            case Style.Nacho:
                nachoCart.SetActive(true);
                break;
            default:
                break;
        }
    }
}
