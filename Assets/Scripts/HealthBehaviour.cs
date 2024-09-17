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
    public UnityEvent< float> OnChangeHealth;

    private void Start()
    {
        invulnerable = false;
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
        OnChangeHealth.Invoke(currentHealth);
    }
    public void Heal(float health)
    {
        currentHealth += health;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        OnChangeHealth.Invoke(currentHealth);

    }

    public void Hurt(float damage)
    {
        if (!invulnerable)
        {
            currentHealth -= damage;
            if(currentHealth<=0)
            {
                OnDie.Invoke();
                currentHealth = 0;
            }
            OnChangeHealth.Invoke(currentHealth);   
        }
    }

    public float GetHealth()
    {
        return currentHealth;
    }
}
