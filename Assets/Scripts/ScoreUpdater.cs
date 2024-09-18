using System;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    public int score;
    public static event Action<int> OnUpdateScore = delegate { };

    public void UpdateScore()
    {
        OnUpdateScore.Invoke(score);
    }
}