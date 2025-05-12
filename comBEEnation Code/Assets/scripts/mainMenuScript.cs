using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class mainMenuScript : MonoBehaviour
{
    public GameObject settingsWindow;
    public TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            // Check if the aspect ratio is 16:9
            float aspectRatio = (float)resolutions[i].width / resolutions[i].height;
            if (Mathf.Approximately(aspectRatio, 16f / 9f))
            {
                filteredResolutions.Add(resolutions[i]);
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                // Check if this is the current resolution
                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = filteredResolutions.Count - 1;
                }
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void setResolution(int resolutionIndex)
    {
        if (resolutionIndex >= 0 && resolutionIndex < filteredResolutions.Count)
        {
            Resolution resolution = filteredResolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            Debug.Log("Resolution set to: " + resolution.width + "x" + resolution.height);
        }
        else
        {
            Debug.LogError("Invalid resolution index.");
        }
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void settings()
    {
        settingsWindow.SetActive(true);
    }

    public void settingsClose()
    {
        settingsWindow.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
