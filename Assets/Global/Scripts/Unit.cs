using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected Stats stats;
    [SerializeField] protected string unitName = "Placeholder";
    private void Start()
    {
        if (stats == null)
            stats = GetComponent<Stats>();


    }

    public virtual void TakeDamage(float damage)
    {
        stats.OnTakeDamage(damage);
        if(stats.Health <= 0)
        {
            Death();
        }
        Debug.Log(unitName + " was hit for: " + damage);
    }

    protected virtual void Death()
    {

    }
}
