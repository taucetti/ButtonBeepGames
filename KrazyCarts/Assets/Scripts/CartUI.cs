using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartUI : MonoBehaviour
{

    public TextMeshProUGUI cartText;
    public TotalCarts totalCarts;
    public CartPickUp cartLine;
    // Start is called before the first frame update
    void Start()
    {
        cartText = GetComponent<TextMeshProUGUI>();
        cartText.text = "0 / " + totalCarts.cartSum.ToString();
    }

    void Update()
    {
        cartText.text = cartLine.cartHolder.ToString() + " / " + totalCarts.cartSum.ToString();
    }
}
