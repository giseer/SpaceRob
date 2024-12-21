using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPanelToggler : MonoBehaviour
{
    [SerializeField] private GameObject statsPanel;
    
    public void ToggleStatPanel()
    {
        statsPanel.SetActive(!statsPanel.activeSelf);
    }
}
