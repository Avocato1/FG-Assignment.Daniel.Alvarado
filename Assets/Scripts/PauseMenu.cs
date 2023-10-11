
using System;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject levelMenuUI;
    private ControllerInputs _controllerInputs;
    
    


    void Update()
    {
        if(_controllerInputs.Player.Escape.triggered )
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
               Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    public void ChangeLevel(string levelName)
    {
        LevelManager.instance.LoadLevel(levelName);
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    private void OnEnable()
    {
        _controllerInputs = new ControllerInputs();
        _controllerInputs.Enable();
    }
    
    private void OnDisable()
    {
        _controllerInputs.Disable();
    }
}
