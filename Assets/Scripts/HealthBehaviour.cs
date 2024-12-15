using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public bool invulnerable;

    public UnityEvent OnDie;
    public UnityEvent<int> OnChangeHealth;

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
                invulnerable = false;
            }
        }
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
        OnChangeHealth.Invoke(currentHealth);
    }

    public void Heal(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        OnChangeHealth.Invoke(currentHealth);
    }

    public void Hurt(int damage)
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
        invulnerable = true;
        remainingTimeOfBlink = blinkTotalTime;
        StartCoroutine(BlinkCourutine(blinkColor));
    }


    private IEnumerator BlinkCourutine(Color blinkColor)
    {
        if (canBlink)
        {
            for (int i = 0; i <= Mathf.FloorToInt(blinkTotalTime / delayBetweenBlinks) + 1; i++)
            {
                renderer.color = renderer.color == Color.white ? blinkColor : Color.white;

                yield return new WaitForSeconds(delayBetweenBlinks);
            }

            renderer.color = Color.white;

            yield return null;
        }
    }
}