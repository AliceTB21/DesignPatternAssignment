using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int currentAmmo;
    [SerializeField] private int maxAmmo;
    [SerializeField] Transform bulletSpawnPos;

    public void Shoot()
    {
        if(currentAmmo <= 0) { Debug.Log("No ammo"); return; }
        Projectile queueBullet = Manager.Instance.GetPool.SpawnBulletPool();
        queueBullet.transform.position = bulletSpawnPos.position;
        currentAmmo--;
    }

    public void StartReload()
    {

    }
}
