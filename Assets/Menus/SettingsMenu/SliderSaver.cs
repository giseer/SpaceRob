using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderSaver : MonoBehaviour
{
    [SerializeField] private Slider slider;
        
    [SerializeField] private string playerPrefName;

    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;

    protected void OnEnable()
    {
        slider.onValueChanged.AddListener(SaveSlider);
    }
    
    private void Start()
    {
        SetupSlider();
        LoadSlider();
    }

    private void SetupSlider()
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
    }

    private void SaveSlider(float value)
    {
        PlayerPrefs.SetFloat(playerPrefName, Math.Clamp(value, minValue, maxValue));
        LoadSlider();
    }
    
    private void LoadSlider()
    {
        slider.value = PlayerPrefs.GetFloat(playerPrefName, minValue);
    }

    protected void OnDisable()
    {
        slider.onValueChanged.RemoveListener(SaveSlider);
    }
}
