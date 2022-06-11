using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    private int healthPoint;
    public int HealthPoint
    {
        get { return healthPoint; }
        protected set
        {
            healthPoint = value;
        }
    }
    public virtual void TakeDamage(int damage)
    {
        if(healthPoint > 0)
        {
            HealthPoint -= damage;
        }       
    }

}
