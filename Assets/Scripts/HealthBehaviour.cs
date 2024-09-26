using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public bool invulnerable;

    public UnityEvent OnDie;
    public UnityEvent<float> OnChangeHealth;

    [Header("Components")] 
    private SpriteRenderer renderer;

    [Header("Blink Values")]
    [SerializeField] private float delayBetweenBlinks;
    [SerializeField] private float blinkTotalTime;
    private float remainingTimeOfBlink;
    private bool canBlink;

    private void Awake()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        invulnerable = false;
    }

    private void Update()
    {
        if (canBlink)
        {
            remainingTimeOfBlink -= Time.deltaTime;
            if (remainingTimeOfBlink <= 0)
            {
                canBlink = false;
            }
        }
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
        OnChangeHealth.Invoke(currentHealth);
    }

    public void Heal(float health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        OnChangeHealth.Invoke(currentHealth);
    }

    public void Hurt(float damage)
    {
        if (!invulnerable)
        {
            currentHealth -= damage;

            Blink(Color.red);
            
            if (currentHealth <= 0)
            {
                OnDie.Invoke();
                currentHealth = 0;
            }

            OnChangeHealth.Invoke(currentHealth);
        }
    }

    private void Blink(Color blinkColor)
    {
        canBlink = true;
        remainingTimeOfBlink = blinkTotalTime;
        Debug.Log("Starting to Blink");
        StartCoroutine(BlinkCourutine(blinkColor));
    }


    private IEnumerator BlinkCourutine(Color blinkColor)
    {
        if (canBlink)
        {
            for (int i = 0; i <= Mathf.FloorToInt(blinkTotalTime / delayBetweenBlinks) + 1; i++)
            {
                Debug.Log("Changing color");
                renderer.color = renderer.color == Color.white ? blinkColor : Color.white;

                yield return new WaitForSeconds(delayBetweenBlinks);
            }

            renderer.color = Color.white;

            yield return null;
        }
    }

    public float GetHealth()
    {
        return currentHealth;
    }
}