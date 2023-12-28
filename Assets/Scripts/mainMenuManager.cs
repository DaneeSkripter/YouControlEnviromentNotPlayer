using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainmenu;
    [SerializeField] private GameObject optionsmenu;
    [SerializeField] private GameObject playmenu;
    [SerializeField] private TMP_Dropdown resolutionMenu;
    [SerializeField] private TMP_Text fpsText;
    public float deltaTime;
    
    Resolution[] resolutions;
    void Start()
    {
        // ADD SUPPORTED RESOLUTIONS TO DROPDOWN
        resolutions = Screen.resolutions;
        resolutionMenu.ClearOptions();
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width}x{resolutions[i].height} {Math.Round(resolutions[i].refreshRateRatio.value)} Hz";
            options.Add(option);
        }
        resolutionMenu.AddOptions(options);
        // CHOOSE CURRENT RESOLUTION
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width}x{resolutions[i].height} {Math.Round(resolutions[i].refreshRateRatio.value)} Hz";
            string currentResolution = $"{Screen.currentResolution.width}x{Screen.currentResolution.height} {Math.Round(Screen.currentResolution.refreshRateRatio.value)} Hz";
            if (option == currentResolution)
            {
                resolutionMenu.value = i;
            }
        }
    }

    // MAIN MENU
    public void executePlayBtn()
    {
        mainmenu.SetActive(false);
        playmenu.SetActive(true);
    }

    public void executeOptionsBtn()
    {
        mainmenu.SetActive(false);
        optionsmenu.SetActive(true);
    }
    
    public void executeExitBtn()
    {
        Application.Quit();
    }
    
    // PLAY MENU
    
    public void executePlaySceneBtn()
    {
        SceneManager.LoadScene("forestScene");
    }
    
    // OPTIONS MENU

    public void setFullscreen(bool value)
    {
        Screen.fullScreen = value;
    }

    public void setResolution(int resolutionIndex)
    { 
        Resolution resolution = resolutions[resolutionIndex]; 
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRateRatio);
    }
    
    public void executeBackBtn()
    {
        playmenu.SetActive(false);
        optionsmenu.SetActive(false);
        mainmenu.SetActive(true);
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = Mathf.Round(1.0f / deltaTime);
        fpsText.text = $"FPS: {fps}";
    }
}
