using TMPro;
using UnityEngine;

public class StatsReader : MonoBehaviour
{
    [Header("Normal Mode Text Fields")]
    [SerializeField] private TextMeshProUGUI normalSurviveValueText;
    [SerializeField] private TextMeshProUGUI normalScoreValueText;
    [SerializeField] private TextMeshProUGUI normalTimeText;
    [SerializeField] private TextMeshProUGUI normalTimeValueText;
    
    [Header("Endless Mode Text Fields")]
    [SerializeField] private TextMeshProUGUI EndlessScoreValueText;
    [SerializeField] private TextMeshProUGUI EndlessTimeValueText;

    private GameData normalModeTempData;
    private GameData endlessModeTempData;
    
    private void Start()
    {
         normalModeTempData  = LoadGameDataByMode(SaveSystem.GameMode.Normal);
         endlessModeTempData = LoadGameDataByMode(SaveSystem.GameMode.Endless);

        UpdateNormalModeValues(normalModeTempData);

        UpdateEndlessModeValues(endlessModeTempData);
    }

    private GameData LoadGameDataByMode(SaveSystem.GameMode mode)
    {
        return SaveSystem.Instance.LoadGameData(mode);
    }

    private void UpdateNormalModeValues(GameData normalModeTempData)
    {
        if (normalModeTempData != null)
        {
            normalSurviveValueText.text = normalModeTempData.gameSurvived ? "YES" : "NO";
            normalScoreValueText.text = $"{normalModeTempData.highScore}";
            normalTimeValueText.text = $"{Mathf.Min(normalModeTempData.highTime,60)} seconds";
        }
        else
        {
            normalSurviveValueText.text = "No Data";
            normalScoreValueText.text = "No Data";
            normalTimeValueText.text = $"No Data";
        }
    }
    
    private void UpdateEndlessModeValues(GameData endlessModeTempData)
    {
        if (endlessModeTempData != null)
        {
            EndlessScoreValueText.text = $"{endlessModeTempData.highScore}";
            EndlessTimeValueText.text = $"{endlessModeTempData.highTime}";
        }
        else
        {
            EndlessScoreValueText.text = "No Data";
            EndlessTimeValueText.text = "No Data";
        }
    }
}
