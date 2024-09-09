using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    [SerializeField] private InputActionReference pause;
    
    private bool isPaused = false;

    private void OnEnable()
    {
        pause.action.Enable();
    }

    void Update()
    {
        if (pause.action.WasPerformedThisFrame())
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();    
            }
            isPaused =!isPaused;
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
    }
    
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("PauseMenu");
    }

    private void OnDisable()
    {
        pause.action.Disable();
    }
}
