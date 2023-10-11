using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
{
    public PauseMenu _pauseMenu;
    public GameObject levelMenuUI;
    private ControllerInputs _controllerInputs;
    private bool levelMenuIsOpen = false;
    
    void Update()
    {
        if (_controllerInputs.Player.Escape.triggered)
        {
            // Check if _pauseMenu is not null before accessing GameIsPaused
            if (_pauseMenu != null && _pauseMenu.GameIsPaused && levelMenuIsOpen)
            {
                Resume();
            }
            else
            {
                _pauseMenu.Pause();
            }
        }
    }

    public void Resume()
    {

        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        levelMenuIsOpen = false;
         _pauseMenu.GameIsPaused = false;
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
