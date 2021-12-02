using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected Stats stats;

    private void Start()
    {
        if (stats == null)
            stats = GetComponent<Stats>();


    }

    public virtual void TakeDamage(float damage)
    {
        stats.OnTakeDamage(damage);

    }
}
