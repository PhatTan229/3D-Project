using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWeapon : MonoBehaviour
{
    public int defaultDamage;
    private int currentDamage;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(currentDamage);
        }
    }
    public void ReduceDamage(int amount)
    {
        currentDamage -= amount;
        //if (currentDamage < 0) currentDamage = 0;
        
    }
    public void IncreaseDamage(int amout)
    {

    }
}
