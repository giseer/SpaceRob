using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;
    
    public static AudioManager Instance { get; private set; }

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    
    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            mainMixer.SetFloat("Music", PlayerPrefs.GetFloat("MusicVolume"));   
        }
        else
        {
            float musicInitialValue;

            mainMixer.GetFloat("Music", out musicInitialValue);
            
            PlayerPrefs.SetFloat("MusicVolume", musicInitialValue);
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            mainMixer.SetFloat("Sfx", PlayerPrefs.GetFloat("SFXVolume"));    
        }
        else
        {
            float sfxInitialValue;

            mainMixer.GetFloat("Sfx", out sfxInitialValue);
            
            PlayerPrefs.SetFloat("SFXVolume", sfxInitialValue);
        }
        
    }
    
    public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("Music", volume);
    }

    public void SetSFXVolume(float volume)
    {
        mainMixer.SetFloat("Sfx", volume);
    }
}
