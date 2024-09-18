using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class Boost : MonoBehaviour
{
    // Art Values
    public Sprite boostSprite;
    private PlayableDirector obtainedAnimation;
    
    // Timer Values
    [SerializeField] private float durationInSeconds;
    [HideInInspector] public float remainingTimeInSeconds;

    // Collision values
    protected Ship lastShipHitted;
    [HideInInspector] public bool boostActivated;
    
    // Abstract methods
    protected virtual void ApplyBoost()
    {
        AnimateObtainBoost();
        Debug.Log("Boost applied");
        remainingTimeInSeconds = durationInSeconds;
        boostActivated = true;
        BoostUIpdater.Instance.activeBoost = this;
    }

    protected virtual void  RemoveBoost()
    {
        Debug.Log("Boost removed");
        boostActivated = false;
        BoostUIpdater.Instance.activeBoost = null;
    }
    
    private void Start()
    {
        obtainedAnimation = GetComponentInParent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInChildren<Ship>())
        {
            lastShipHitted = other.GetComponentInChildren<Ship>();
            
            if (boostActivated == false)
            {
                ApplyBoost();   
            }
        }
    }
    
    private void Update()
    {
        CountdownTimer();
    }

    private void CountdownTimer()
    {
        if (boostActivated)
        {
            remainingTimeInSeconds -= Time.deltaTime;
            Debug.Log(remainingTimeInSeconds);
            if (remainingTimeInSeconds <= 0f)
            {
                remainingTimeInSeconds = 0f;
                Debug.Log("Need To Remove Boost");
                RemoveBoost();
            }
        }
    }
    
    public void AnimateObtainBoost()
    {
        obtainedAnimation.Play();
        Destroy(transform.parent.gameObject, durationInSeconds + 1f);
    }
}
