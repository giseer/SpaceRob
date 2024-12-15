using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class EndGameEvaluator : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ScoreBehaviour scoreBehaviour;
    [SerializeField] private TimerBehaviour timerBehaviour;
    [SerializeField] private HealthBehaviour healthBehaviour;
    
    [Header("Canvas")]
    [SerializeField] private GameObject completeCanvas;
    [SerializeField] private GameObject uncompleteCanvas;
    
    [Header("Canvas Fields")]
    [SerializeField] private TextMeshProUGUI newRecordText;
    [SerializeField] private TextMeshProUGUI newTimeText;
    
    public void CheckEndGame(bool isComplete)
    {
        if (isComplete)
        {
            CheckEndScore();
        }
        else
        {
            CheckEndTime();
        }
    }

    private void CheckEndScore()
    {
        completeCanvas.SetActive(true);
        
        if (SaveSystem.Instance.LoadGameData() != null)
        {
            IsNewRecord(scoreBehaviour.score > SaveSystem.Instance.LoadGameData().highScore);
        }
        else
        {
            IsNewRecord(true);   
        }
    }
    
    private void IsNewRecord(bool isNewRecord)
    {
        if (isNewRecord)
        {
            newRecordText.text = $"New record: {scoreBehaviour.score}";
            newRecordText.gameObject.SetActive(true);
            
            SaveSystem.Instance.SaveGameData(new GameData(
                (int)timerBehaviour.time,
                scoreBehaviour.score, 
                healthBehaviour.currentHealth,
                true));
        }
        else
        {
            newRecordText.gameObject.SetActive(false);
        }
    }

    private void CheckEndTime()
    {
        uncompleteCanvas.SetActive(true);
        
        if (SaveSystem.Instance.LoadGameData() != null)
        {
            int gameTime = (int)Mathf.Round(timerBehaviour.initialTime - timerBehaviour.time);

            IsNewTime(gameTime > SaveSystem.Instance.LoadGameData().highTime);
        }
        else
        {
            IsNewTime(true);   
        }
    }
    
    private void IsNewTime(bool isNewTime)
    {
        if (isNewTime)
        {
            newTimeText.text = $"New Time: {Mathf.Round(timerBehaviour.initialTime - timerBehaviour.time)} seconds";
            newTimeText.gameObject.SetActive(true);
            
            SaveSystem.Instance.SaveGameData(new GameData(
                (int)Mathf.Round(timerBehaviour.initialTime - timerBehaviour.time),
                scoreBehaviour.score, 
                healthBehaviour.currentHealth,
                false));
        }
        else
        {
            newTimeText.gameObject.SetActive(false);
        }
    }
}
