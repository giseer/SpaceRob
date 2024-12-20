using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;

    public void TogglePauseCanvas()
    {
        pauseCanvas.SetActive(!pauseCanvas.activeSelf);

        Time.timeScale = pauseCanvas.activeSelf ? 0 : 1;
    }
}
