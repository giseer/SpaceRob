using TMPro;
using UnityEngine;

public class LifesTextUpdate : MonoBehaviour
{
    public void SetLifesText(float lifes)
    {
        GetComponent<TMP_Text>().text = "Lifes: " + lifes;
    }
}