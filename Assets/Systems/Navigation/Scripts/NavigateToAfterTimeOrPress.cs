using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NavigateToAfterTimeOrPress : MonoBehaviour
{
    [SerializeField] string sceneToNavigateTo;
    [SerializeField] float waitTime = 5f;
    [SerializeField] InputActionReference skip;
    
    private bool alreadySkipped = false;

    private void OnEnable()
    {
        skip.action.Enable();
    }

    private void Start()
    {
        Invoke(nameof(NavigateToNextScene), waitTime);
        
    }

    private void Update()
    {
        if (skip.action.WasPerformedThisFrame())
        {
            SkipScene();
        }
    }

    void NavigateToNextScene()
    {
        NavigatorManager.LoadScene(sceneToNavigateTo); 
    }

    void SkipScene()
    {
        NavigateToNextScene();
        Debug.Log("Scene Skipped");
    }

    private void OnDisable()
    {
        skip.action.Disable();
    }
    
}