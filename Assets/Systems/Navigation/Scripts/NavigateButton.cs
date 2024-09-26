using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NavigateButton : MonoBehaviour
{
    [SerializeField] private string sceneToLoadName;

    private Button _button;

    private Button[] allActiveButtons;

    private bool alreadyPressed;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        
        allActiveButtons = FindObjectsOfType<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(NavigateToSceneToLoad);
    }

    private void NavigateToSceneToLoad()
    {
        if (!alreadyPressed)
        {
            ResumeGameTime();
            
            DesactiveActiveButtons();
            
            NavigatorManager.LoadScene(sceneToLoadName);
            alreadyPressed = true;
        }
    }

    private void ResumeGameTime()
    {
        Time.timeScale = 1f;
    }
    
    private void DesactiveActiveButtons()
    {
        foreach (var activeButton in allActiveButtons)
        {
            activeButton.enabled = false;
        }
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(NavigateToSceneToLoad);
    }
}
