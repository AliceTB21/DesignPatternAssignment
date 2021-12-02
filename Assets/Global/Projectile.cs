using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileDamage;
    [SerializeField] private float timeUntilPool;
    private float timer;
    private void OnTriggerEnter(Collider other)
    {
        Unit hitUnit = other.GetComponent<Unit>();
        if(hitUnit)
        {
            hitUnit.TakeDamage(projectileDamage);
        }

        Manager.Instance.GetPool.ReturnToPool(this.gameObject);
    }

    public void RestartTimer()
    {
        timer = timeUntilPool;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Manager.Instance.GetPool.ReturnToPool(this.gameObject);
        }
    }
}
