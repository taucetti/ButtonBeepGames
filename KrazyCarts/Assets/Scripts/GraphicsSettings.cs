using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsSettings : MonoBehaviour
{
    public void LowGraphics() // below sets all the graphics to what the player chooses it references "Quality" in unity project settings
    {
        QualitySettings.SetQualityLevel(0); // sets the graphics to low
    }

    public void MediumGraphics()
    {
        QualitySettings.SetQualityLevel(1); // sets the graphics to medium
    }

    public void HighGraphics()
    {
        QualitySettings.SetQualityLevel(2); // sets the graphics to high
    }
}
