using System;
using UnityEngine;
using UnityEngine.Playables;

public class Boost : MonoBehaviour
{
    [Header("Art Values")] 
    public Sprite boostSprite;

    [Header("Timer Values")] 
    [SerializeField] private float durationInSeconds;

    [HideInInspector] public float remainingTimeInSeconds;
    [HideInInspector] public bool boostActivated;

    [Header("Collision values")] protected Ship lastShipHitted;

    [Header("TimeLines Values")]
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private PlayableAsset boostObtainedClip;
    [SerializeField] private PlayableAsset boostSpawnedClip;

    private void Awake()
    {
        playableDirector = GetComponentInParent<PlayableDirector>();
        playableDirector.playableAsset = boostSpawnedClip;
        playableDirector.Play();
    }

    private void Update()
    {
        CountdownTimer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInChildren<Ship>())
        {
            lastShipHitted = other.GetComponentInChildren<Ship>();

            if (boostActivated == false) ApplyBoost();
        }
    }

    //Abstract Methods
    protected virtual void ApplyBoost()
    {
        AnimateObtainBoost();
        Debug.Log("Boost applied");
        remainingTimeInSeconds = durationInSeconds;
        boostActivated = true;
        BoostUIpdater.Instance.activeBoost = this;
    }

    protected virtual void RemoveBoost()
    {
        Debug.Log("Boost removed");
        boostActivated = false;
        BoostUIpdater.Instance.activeBoost = null;
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
        playableDirector.playableAsset = boostObtainedClip;
        playableDirector.Play();
        Destroy(transform.parent.gameObject, durationInSeconds + 1f);
    }
}