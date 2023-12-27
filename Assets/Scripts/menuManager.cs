using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenu;

    [SerializeField] private Canvas controlMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void showHideControlMenu()
    {
        if (controlMenu.gameObject.activeInHierarchy)
        {
            controlMenu.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            if (pauseMenu.gameObject.activeInHierarchy)
            {
                pauseMenu.gameObject.SetActive(false);
            }
            controlMenu.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
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
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showHidePauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
         showHideControlMenu();   
        }
    }
}
