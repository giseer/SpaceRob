using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NavigateButton : MonoBehaviour
{
    [SerializeField] private string sceneToLoadName;

    private Button _button;

    private bool alreadyPressed;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(NavigateToSceneToLoad);
    }

    private void NavigateToSceneToLoad()
    {
        if (!alreadyPressed)
        {
            NavigatorManager.LoadScene(sceneToLoadName);
            alreadyPressed = true;
        }
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(NavigateToSceneToLoad);
    }
}
