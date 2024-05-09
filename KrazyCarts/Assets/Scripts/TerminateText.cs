using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminateText : MonoBehaviour
{
    public TextMeshProUGUI number;
    public TextMeshProUGUI building;
    public TextMeshProUGUI ownerName;
    // Start is called before the first frame update
    void Start()
    {
        if (LastActiveScene.buildID == 4)// Level One
        {
            number.text = "One";
            building.text = "BIL";
            ownerName.text = "Bil";
        }
        else if (LastActiveScene.buildID == 5)// Level Two
        {
            number.text = "Two";
            building.text = "De Juicy Junction";
            ownerName.text = "Juicy";
        }
        else if (LastActiveScene.buildID == 9)// Level Three
        {
            number.text = "Three";
            building.text = "Niko's Nachos";
            ownerName.text = "Niko";
        }
    }
}