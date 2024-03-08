using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResolutionManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resoultionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;

    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resoultionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> resolutionNames = new List<string>();
        for (int i = 0;i < filteredResolutions.Count;i++)
        {
            string resolutionOption = filteredResolutions[i].width+ "x"+ filteredResolutions[i].height; " " + filteredResolutions[i].refreshRate + " Hz";
            options.Add(resolutionOption);
            if (filteredResolutions[i].width==Screen.width && filteredResolutions[i].height==Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resoultionDropdown.AddOptions(options);
        resoultionDropdown.value = currentResolutionIndex;
        resoultionDropdown.RefreshShownValue();
    }

   
}
