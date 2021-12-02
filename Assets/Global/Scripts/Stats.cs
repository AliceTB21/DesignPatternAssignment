using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    public float Health { get { return currentHealth; } protected set { currentHealth = value; } }

    public virtual void OnTakeDamage(float incomingDamage)
    {
        Health -= incomingDamage;

        if(Health <= 0)
        {
            Debug.Log("Dead");

        }
    }

    public virtual void OnHeal(float healAmount)
    {
        Health += healAmount;
        Health = Mathf.Clamp(healAmount, 0, maxHealth);
    }
}
