using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class EndGameEvaluator : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ScoreBehaviour scoreBehaviour;
    [SerializeField] private TimerBehaviour timerBehaviour;
    [SerializeField] private HealthBehaviour healthBehaviour;
    [SerializeField] private AudioSource audioSource;
    
    [Header("Canvas")]
    [SerializeField] private GameObject completeCanvas;
    [SerializeField] private GameObject uncompleteCanvas;
    
    [Header("Fanfares")]
    [SerializeField] private AudioClip completeFanfare;
    [SerializeField] private AudioClip uncompleteFanfare;
    
    [Header("Canvas Fields")]
    [SerializeField] private TextMeshProUGUI newRecordText;
    [SerializeField] private TextMeshProUGUI newTimeText;

    [Header("Values")] 
    [SerializeField] private SaveSystem.GameMode gameMode;
    
    private bool _survived;
    
    public void CheckEndGame(bool isComplete)
    {
        PlayEndGameSound(isComplete ? completeFanfare : uncompleteFanfare);
        ShowEndCanvas(isComplete? completeCanvas : uncompleteCanvas);
        
        _survived = isComplete;
        
        CheckEndScore();
        CheckEndTime();
    }

    private void ShowEndCanvas(GameObject canvasToShow)
    {
        canvasToShow.SetActive(true);
    }

    private void PlayEndGameSound(AudioClip sound)
    {
        audioSource.clip = sound;
        audioSource.Play();
    }

    private void CheckEndScore()
    {
        if (SaveSystem.Instance.LoadGameData(gameMode) != null)
        {
            IsNewRecord(scoreBehaviour.score > SaveSystem.Instance.LoadGameData(gameMode).highScore);
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
                _survived),gameMode);
        }
        else
        {
            newRecordText.gameObject.SetActive(false);
        }
    }

    private void CheckEndTime()
    {
        if (SaveSystem.Instance.LoadGameData(gameMode) != null)
        {
            int gameTime;
            
            switch (gameMode)
            {
                case SaveSystem.GameMode.Normal:
                    gameTime = (int)Mathf.Round(timerBehaviour.initialTime - timerBehaviour.time);
                    
                    IsNewTime(gameTime > SaveSystem.Instance.LoadGameData(gameMode).highTime, gameTime);       
                    break;
                case SaveSystem.GameMode.Endless:
                    gameTime = (int)timerBehaviour.time;
                    
                    IsNewTime(gameTime > SaveSystem.Instance.LoadGameData(gameMode).highTime, gameTime);
                    break;
            }
        }
        else
        {
            IsNewTime(true, (int)timerBehaviour.time);   
        }
    }
    
    private void IsNewTime(bool isNewTime, int newTime)
    {
        if (isNewTime)
        {
            newTimeText.text = $"New Time: {newTime} seconds";
            newTimeText.gameObject.SetActive(true);
            
            SaveSystem.Instance.SaveGameData(new GameData(
                newTime,
                scoreBehaviour.score, 
                healthBehaviour.currentHealth,
                _survived),gameMode);
        }
        else
        {
            newTimeText.gameObject.SetActive(false);
        }
    }
}
