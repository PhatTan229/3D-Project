using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public float maxArmor;
    private float _armor;
    public float armor
    {
        get => _armor;
        set
        {
            _armor = value;
            onHealthChanged.Invoke();
        }
    }
    public UnityEvent onArmorChange;
    public override void TakeDamage(int damage)
    {
        float damageOnArmor = Random.Range(damage / 2, damage);
        float damageOnHealth = damage - damageOnArmor;
        float redundantDamage = damageOnArmor - armor;
        if (redundantDamage <= 0)
        {
            armor -= damageOnArmor;
        }
        else
        {
            armor = 0;
            damageOnHealth += redundantDamage;
        }
        HealthPoint -= damageOnHealth;
        anim.SetTrigger("Hit");
        if (HealthPoint <= 0) Debug.Log($"{gameObject.name} dead");
    }
}
