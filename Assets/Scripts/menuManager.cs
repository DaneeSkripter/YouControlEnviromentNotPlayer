using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenu;

    [SerializeField] private Canvas controlMenu;
    
    
    
    public void showHidePauseMenu()
    {
        if (pauseMenu.gameObject.activeInHierarchy)
        {
            pauseMenu.gameObject.SetActive(false);
            controlMenu.gameObject.SetActive(true);
        }
        else
        {
            if (controlMenu.gameObject.activeInHierarchy)
            {
                controlMenu.gameObject.SetActive(false);
            }
            pauseMenu.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void enterMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showHidePauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            } else if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
