using TMPro;
using UnityEngine;

public class LifesTextUpdate : MonoBehaviour
{
    public void SetLifesText(int lifes)
    {
        GetComponent<TMP_Text>().text = "Lifes: " + lifes;
    }
}