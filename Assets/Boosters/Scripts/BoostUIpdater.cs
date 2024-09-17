using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BoostUIpdater : MonoBehaviour
{
    [SerializeField] private GameObject boostCanvas;
    
    [SerializeField] private Image boostImage;

    [SerializeField] private TextMeshProUGUI boostTimerTMP;

    [HideInInspector] public Boost activeBoost;

    private bool boostCanvasInitialized;
    
    public static BoostUIpdater Instance { get; private set; }

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

    private void Update()
    {
        if (activeBoost)
        {
            if (!boostCanvasInitialized)
            {
                boostCanvasInitialized = true;
                boostCanvas.gameObject.SetActive(true);
            }

            boostImage.sprite = activeBoost.boostSprite;
            boostTimerTMP.text = activeBoost.remainingTimeInSeconds.ToString("F2");
        }
        else
        {
            if (boostCanvasInitialized)
            {
                boostCanvasInitialized = false;
                boostCanvas.gameObject.SetActive(false);
            }
        }
    }
}
