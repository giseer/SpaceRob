using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int highScore;
    public int highTime;
    public int highLifesSurvived;
    public bool gameSurvived;

    public GameData(int highTime, int highScore, int highLifesSurvived, bool gameSurvived)
    {
        this.highTime = highTime;
        this.highScore = highScore;
        this.highLifesSurvived = highLifesSurvived;
        this.gameSurvived = gameSurvived;
    }
}
