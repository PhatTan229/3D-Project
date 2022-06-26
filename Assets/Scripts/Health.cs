using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealthPoint;
    protected float healthPoint;
    protected float HealthPoint
    {
        get => healthPoint;
        set
        {
            healthPoint = value;
            onHealthChanged.Invoke();
        }
    }
    public int disappearingDelay;
    public bool isAlive;
    public UnityEvent onHealthChanged;
    public UnityEvent onDead;
    public Animator anim;
    private void Start()
    {
        HealthPoint = maxHealthPoint;
        isAlive = true;
    }
    public virtual void TakeDamage(int damage)
    {
        HealthPoint -= damage;
        if (HealthPoint <= 0)
        {
            anim.SetTrigger("Dead");
            isAlive = false;
            onDead.Invoke();
            Destroy(gameObject, disappearingDelay);
        }
        else
        {
            Debug.Log($"Before health {HealthPoint} damage {damage}");
            anim.SetTrigger("Hit");
            Debug.Log($"After health {HealthPoint}");
        }
        
    }
}
