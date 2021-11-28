using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public delegate void OnHealthChanged(float oldHealth, float newHealth);
    public event OnHealthChanged onHealthChanged;

    public float GetHealth { get { return stats.Health; } }

    public override void TakeDamage(float damage)
    {
        onHealthChanged.Invoke(stats.Health, stats.Health - damage);
        base.TakeDamage(damage);

    }

    private void Start()
    {
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) // Take damage by pressing E for testing purposes
        {
            TakeDamage(2);
        }
    }

}
