using System;
using TMPro;
using UnityEngine;

public class TimeTextUpdater : MonoBehaviour
{
    public void SetTimeText(float time)
    {
        GetComponent<TMP_Text>().text = "Time: " + (int)time;
    }
}