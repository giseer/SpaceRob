using TMPro;
using UnityEngine;

public class GameRecordsReader : MonoBehaviour
{
    [Header("Components")] 
    private TextMeshProUGUI textMesh;
    
    private void Awake()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameData currentGameData;
        currentGameData = SaveSystem.Instance.LoadGameData();

        if (currentGameData == null) return;
        
        UpdateText(currentGameData);
    }

    private void UpdateText(GameData currentGameData)
    {
        if (currentGameData.gameSurvived)
        {
            textMesh.text = $"Best Score: {currentGameData.highScore}";
        }
        else
        {
            textMesh.text = $"Best Time: {currentGameData.highTime} seconds";
        }
    }
}
