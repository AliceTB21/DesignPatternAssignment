using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Weapon primary;
    private Weapon secondary;

    private Weapon currentWeapon;

    public Weapon GetCurrentWeapon { get { return currentWeapon; } set { currentWeapon = value; } }
}
