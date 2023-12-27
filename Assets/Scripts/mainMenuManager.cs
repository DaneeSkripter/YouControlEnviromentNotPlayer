using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainmenu;
    [SerializeField] private GameObject optionsmenu;
    [SerializeField] private GameObject playmenu;
    [SerializeField] private TMP_Dropdown resolutionMenu;

    void Start()
    {
        string currentResolution = $"{Screen.currentResolution.width}x{Screen.currentResolution.height}";
        int optionIndex = -1;
        foreach (TMP_Dropdown.OptionData option in resolutionMenu.options)
        {
            optionIndex++;
            if (option.text == currentResolution)
            {
                resolutionMenu.value = optionIndex;
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

    public void setResolution(int value)
    {
       int width = int.Parse(resolutionMenu.options[resolutionMenu.value].text.Split("x")[0]);
       int height = int.Parse(resolutionMenu.options[resolutionMenu.value].text.Split("x")[1]);
       Screen.SetResolution(width, height, Screen.fullScreen);
    }
    
    public void executeBackBtn()
    {
        playmenu.SetActive(false);
        optionsmenu.SetActive(false);
        mainmenu.SetActive(true);
    }
}
