using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Queue<GameObject> bulletPool = new Queue<GameObject>();
    [SerializeField] private int poolSize = 30;


    private void Start()
    {
        StartPool();
    }

    private void Update()
    {
        
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
            GameObject bulletGO = Instantiate(projectilePrefab);
            bulletGO.SetActive(false);
            bulletPool.Enqueue(bulletGO);
        }
    }

    public GameObject SpawnBulletPool() // Attempts to dequeue a bullet and instantiates if there's none
    {
        if (bulletPool.TryDequeue(out GameObject bullet))
        {
            bullet.SetActive(true);
            bullet.GetComponent<Projectile>().RestartTimer();
            return bullet;
        }
        else
            return Instantiate(projectilePrefab);
    }

    public void ReturnToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
