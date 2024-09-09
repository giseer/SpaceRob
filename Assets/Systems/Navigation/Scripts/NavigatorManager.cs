using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class NavigatorManager : MonoBehaviour
{
    private static NavigatorManager _instance;

    [SerializeField] private string firstSceneToLoad;
    private CanvasGroup _canvasGroup;
    private Scene _lastLoadedScene;

    private void Awake()
    {
        _instance = this;
        _canvasGroup = GetComponentInChildren<CanvasGroup>();
    }

    private void Start()
    {
        LoadScene(firstSceneToLoad);
    }

    public static void LoadScene(string sceneName)
    {
        _instance.LoadSceneInternal(sceneName);
    }

    private void LoadSceneInternal(string sceneName)
    {
        if (!sceneName.Equals(""))
        {
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }        
    }

    public static void UnloadScene(string sceneName)
    {
        UnloadSceneInternal(sceneName);
    }

    private static void UnloadSceneInternal(string sceneName)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(sceneName));
    }


    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        if(_lastLoadedScene.isLoaded)
        {
            Tween fadeOut = _canvasGroup.DOFade(1f, 3f);
            while (!fadeOut.playedOnce)
            {
                yield return null;
            }
            yield return new WaitForSeconds(3f);
            
            AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(_lastLoadedScene);
            while (!unloadOperation.isDone)
            {
                yield return null;
            }
        }
        
        
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!loadOperation.isDone)
        {
            yield return null;
        }
        

        _lastLoadedScene = SceneManager.GetSceneByName(sceneName);
        
        Tween fadeIn = _canvasGroup.DOFade(0f, 3f);
        
        while (!fadeIn.playedOnce)
        {
            yield return null;
        }
        yield return new WaitForSeconds(3f);
    }
}
