using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealthPoint;
    private float healthPoint;
    protected float HealthPoint
    {
        get => healthPoint;
        set
        {
            healthPoint = value;
            onHealthChanged.Invoke();
        }
    }
    public UnityEvent onHealthChanged;

    public virtual void TakeDamage(int damage)
    {
        if (healthPoint > 0)
        {
            HealthPoint -= damage;
        }       
    }
}
