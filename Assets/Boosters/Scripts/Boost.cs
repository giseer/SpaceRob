using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public enum BoostType
{
    x2,
    flash,
    invulnerability
}

public class Boost : MonoBehaviour
{
    public BoostType type;

    public float durationInSeconds;
    
    private PlayableDirector obtainedAnimation;

    private void Start()
    {
        obtainedAnimation = GetComponentInParent<PlayableDirector>();
    }

    public void AnimateObtainBoost()
    {
        obtainedAnimation.Play();
        Destroy(transform.parent.gameObject, (float)obtainedAnimation.duration);
    }
}
