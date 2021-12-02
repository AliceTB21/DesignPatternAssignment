using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public delegate void OnHealthChanged(float oldHealth, float newHealth);
    public event OnHealthChanged onHealthChanged;

    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private PlayerMovement movement;
    public float GetHealth { get { return stats.Health; } }

    private void Start()
    {
        if(!weaponManager)
        weaponManager = GetComponent<WeaponManager>();
        if (!movement)
            movement = GetComponent<PlayerMovement>();
    }

    public override void TakeDamage(float damage) // Substracts health with damage and invokes the onHealthChanged to subscribed methods
    {
        onHealthChanged.Invoke(stats.Health, stats.Health - damage);
        base.TakeDamage(damage);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) // Take damage by pressing E for testing purposes
        {
            TakeDamage(2);
        }
        if(Input.GetButtonDown("Fire1"))
        {
            if(!weaponManager.GetCurrentWeapon) { Debug.Log("No weapon equipped"); return; }
            weaponManager.GetCurrentWeapon.Shoot();
        }
    }

}
