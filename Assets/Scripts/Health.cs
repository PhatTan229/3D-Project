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
    public Animator anim;
    private void Start()
    {
        HealthPoint = maxHealthPoint;
    }
    public virtual void TakeDamage(int damage)
    {
        HealthPoint -= damage;
        if (HealthPoint <= 0)
        {
            anim.SetTrigger("Dead");
        }
        else
        {
            anim.SetTrigger("Hit");
        }
        
    }
}
