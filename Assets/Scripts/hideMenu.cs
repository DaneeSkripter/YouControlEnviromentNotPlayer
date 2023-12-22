using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    // Start is called before the first frame update
    public void checkIfMenuIsHidden()
    {
        if (menu.activeInHierarchy)
        {
            HideMenu();
        }
        else
        {
            ShowMenu();
        }
    }

    void HideMenu()
    {
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ShowMenu()
    {
        menu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    { 
        if (Input.GetKey(KeyCode.Escape))
        {
            ShowMenu();
        }
    }
}
