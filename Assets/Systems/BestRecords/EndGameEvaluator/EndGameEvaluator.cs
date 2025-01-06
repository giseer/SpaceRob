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
        GameData gameData = SaveSystem.Instance.LoadGameData(gameMode);
        
        if (gameData != null)
        {
            IsNewRecord(scoreBehaviour.score > gameData.highScore);
        }
        else
        {
            if (scoreBehaviour.score > 0)
            {
                IsNewRecord(true);       
            }
        }
    }
    
    private void IsNewRecord(bool isNewRecord)
    {
        if (isNewRecord)
        {
            newRecordText.text = $"New record: {scoreBehaviour.score} points";
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
        GameData gameData = SaveSystem.Instance.LoadGameData(gameMode);
        
        if (gameData != null)
        {
            int gameTime;

            if (gameMode == SaveSystem.GameMode.Normal)
            {
                gameTime = (int)Mathf.Round(timerBehaviour.initialTime - timerBehaviour.time);
            }
            else if (gameMode == SaveSystem.GameMode.Endless)
            {
                gameTime = (int)timerBehaviour.time;
            }
            else
            {
                Debug.LogError("GameMode no exists");
                gameTime = 0;
            }
            
            IsNewTime(gameTime > gameData.highTime, gameTime);     
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
