using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreBehaviour : MonoBehaviour
{
    public int score;
    public UnityEvent<int> OnChangeScore;

    private void OnEnable()
    {
        ScoreUpdater.OnUpdateScore += AddScore;
    }

    private void OnDisable()
    {
        ScoreUpdater.OnUpdateScore -= AddScore;
    }

    private void Start()
    {
        score = 0;
    }

    public void AddScore(int d)
    {
        score += d;
        OnChangeScore.Invoke(score);
    }

    public void RestartScore()
    {
        score = 0;
        OnChangeScore.Invoke(score);
    }
}
