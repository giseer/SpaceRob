using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public static PauseManager Instance { get; private set; }

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == "PauseMenu")
            {
                NavigatorManager.UnloadScene("PauseMenu");
            }
        }
    }
    
    [SerializeField] private InputActionReference pause;

    public UnityEvent ResumedGame;
    
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
        ResumedGame.Invoke();
    }

    private void OnDisable()
    {
        pause.action.Disable();
    }
}
