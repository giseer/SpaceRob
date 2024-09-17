using UnityEngine;
using UnityEngine.UI;

public class AudioSliderSaver : SliderSaver
{
    enum AudioType
    {
        Music,
        SFX,
    }
    
    [SerializeField] private AudioType type;
    
    private Slider audioSlider;

    private void OnEnable()
    {
        audioSlider.onValueChanged.AddListener(ChangeAudioValues);
        
        base.OnEnable();
    }
    
    private void Awake()
    {
        audioSlider = GetComponentInChildren<Slider>();
    }

    private void ChangeAudioValues(float value)
    {
        if (type == AudioType.Music)
        { 
            Debug.Log("ChangingMusicValues...");
            AudioManager.Instance.SetMusicVolume(value);
        }
        else if (type == AudioType.SFX)
        {
            Debug.Log("ChangingSfxValues...");
            AudioManager.Instance.SetSFXVolume(value);
        }
    }
    
    private void OnDisable()
    {
        audioSlider.onValueChanged.RemoveListener(ChangeAudioValues);
        
        base.OnDisable();
    }
}
