using System;
using UnityEngine;
using UnityEngine.UI;

public class ExitBtn : MonoBehaviour
{
    private Button btn;

    private void Awake()
    {
        btn = GetComponentInChildren<Button>();
    }

    private void OnEnable()
    {
        btn.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        Application.Quit();
    }
    
    private void OnDisable()
    {
        btn.onClick.RemoveListener(Exit);
    }
}
