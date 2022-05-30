using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingController : MonoBehaviour
{
    public GameObject resDropdown;
    
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolution;

    private void Start()
    {
        resDropdown = GameObject.FindGameObjectWithTag("Resolution");
        resolutionDropdown = resDropdown.GetComponent<TMP_Dropdown>();
        resolution = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

            for (int i = 0; i < resolution.Length; i++) 
            {

                string option = resolution[i].width + " x " + resolution[i].height;
                options.Add(option);

                if (resolution[i].width == Screen.currentResolution.width && resolution[i].height == Screen.currentResolution.height) 
                {
                    currentResolutionIndex = i;
                }
            }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void Setresolution( int resolutionIndex) {

        Resolution resolutions = resolution[resolutionIndex];
        Screen.SetResolution(resolutions.width,resolutions.height,Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex) {
        //print(qualityIndex);
        //GameData.current = SaveLoad.savedGames[0];
        //GameData.current.currentQualityIndex = qualityIndex;

        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetfullScreen(bool isfullscreen) {

        Screen.fullScreen = isfullscreen;
    }
}
