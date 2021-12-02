using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Weapon primary;
    private Weapon secondary;

    [SerializeField] private Weapon currentWeapon;

    [SerializeField] private Transform weaponHolder;
    [SerializeField] Weapon test;

    public Weapon GetCurrentWeapon { get { return currentWeapon; } set { currentWeapon = value; } }

    private void Start()
    {
       Weapon weaponGO = Instantiate(test, weaponHolder);
        primary = weaponGO;
        SetCurrentWeapon(weaponGO);

        Debug.Log("Spawned weapon;" + currentWeapon);
    }

    public void SetCurrentWeapon(Weapon newCurrent)
    {
        GetCurrentWeapon = newCurrent;
    }
}
