using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;
    GameObject lights;
    GameObject selectScreen;
    float currentRefreshRate;
    int currentResolutionIndex;
    
    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionOption = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(resolutionOption);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        selectScreen = GameObject.Find("Select Screen").gameObject;
        lights = GameObject.Find("Lights").gameObject;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);

    }
    public void Play()
    {
        SceneManager.LoadScene(1);
        
    }
    public void Multiplayer()
    {

    }
    public void Settings(GameObject settings)
    {
        if (!settings.activeInHierarchy)
        {
            EventSystem eventsys = FindFirstObjectByType<EventSystem>();
            Debug.Log("settings is " + !settings.activeInHierarchy);
            settings.SetActive(true);
            lights.SetActive(false);
            selectScreen.SetActive(false);
            eventsys.SetSelectedGameObject(GameObject.Find("Exit (Settings)"));

        }
        else if (settings.activeInHierarchy)
        {
            EventSystem eventsys = FindFirstObjectByType<EventSystem>();
            Debug.Log("settings is " + !settings.activeInHierarchy);
            settings.SetActive(false);
            lights.SetActive(true);
            selectScreen.SetActive(true);
            eventsys.SetSelectedGameObject(GameObject.Find("Settings Button"));
        }
    }
    public void Tutorial(GameObject text)
    {
        
        if (!text.activeInHierarchy)
        {
            text.SetActive(true);
        }
        else text.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
