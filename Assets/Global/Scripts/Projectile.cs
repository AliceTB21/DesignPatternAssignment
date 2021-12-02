using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [Header("Projectile Info")]
    [SerializeField] private float projectileDamage;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody rb;

    [Header("Pooling")]
    [SerializeField] private float timeUntilPool;
    private float timer;


    private void Start()
    {
        if (!rb)
            rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Unit hitUnit = other.GetComponent<Unit>();
        if(hitUnit)
        {
            hitUnit.TakeDamage(projectileDamage);
        }

        Manager.Instance.GetPool.ReturnToPool(this);
    }

    public void RestartTimer()
    {
        timer = timeUntilPool;
    }

    private void Update()
    {
        PoolReturnTimer();

        transform.position += Vector3.forward * projectileSpeed * Time.deltaTime;
    }

    private void PoolReturnTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Manager.Instance.GetPool.ReturnToPool(this);
        }
    }
}
