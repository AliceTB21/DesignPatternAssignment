using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Queue<Projectile> bulletPool = new Queue<Projectile>();
    [SerializeField] private int poolSize = 30;


    private void Start()
    {
        StartPool();
    }

    private void StartPool() // Runs at start to instantiate the bullets
    {
        for(int i = 0; i < poolSize; i++)
        {
            if(!projectilePrefab)
            {
                Debug.LogError("Projectile prefab null");
                return;
            }
            Projectile bulletGO = Instantiate(projectilePrefab);
            bulletGO.gameObject.SetActive(false);
            bulletPool.Enqueue(bulletGO);
        }
    }

    public Projectile SpawnBulletPool() // Attempts to dequeue a bullet and instantiates if there's none
    {
        if (bulletPool.TryDequeue(out Projectile bullet))
        {
            bullet.gameObject.SetActive(true);
            bullet.RestartTimer();
            return bullet;
        }
        else
            return Instantiate(projectilePrefab);
    }

    public void ReturnToPool(Projectile bullet) // Tells the bullet to enter the queue
    {
        bullet.gameObject.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
