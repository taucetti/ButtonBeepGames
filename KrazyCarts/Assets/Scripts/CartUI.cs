using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartUI : MonoBehaviour
{

    public TextMeshProUGUI cartText;
    public TotalCarts totalCarts;
    // Start is called before the first frame update
    void Start()
    {
        cartText = GetComponent<TextMeshProUGUI>();
        cartText.text = "0 / " + totalCarts.cartSum.ToString();
    }

    public void updateCartText(CartCollection cartCollection)
    {
        cartText.text = cartCollection.NumberOfCarts.ToString() + " / " + totalCarts.cartSum.ToString();
    }
}
