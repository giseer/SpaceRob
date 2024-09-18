using TMPro;
using UnityEngine;

public class ScoreTextUpdater : MonoBehaviour
{
    public void SetScoreText(int score)
    {
        GetComponent<TMP_Text>().text = "Score: " + score;
    }
}