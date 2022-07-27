using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public float maxArmor;
    [SerializeField]
    private float _armor;
    public float Armor
    {
        get => _armor;
        set
        {
            _armor = value;
            onArmorChanged.Invoke();
        }
    }
    public UnityEvent onArmorChanged;
    protected override void Start()
    {
        base.Start();
        Armor = maxArmor;
    }

    public override void TakeDamage(float damage)
    {
        float damageOnArmor = Random.Range((float)(damage / 2), damage);
        float damageOnHealth = damage - damageOnArmor;
        float redundantDamage = damageOnArmor - Armor;
        if (redundantDamage <= 0)
        {
            Armor -= damageOnArmor;
        }
        else
        {
            Armor = 0;
            damageOnHealth += redundantDamage;
        }
        
        HealthPoint -= damageOnHealth;
        
        if (HealthPoint <= 0)
        {
            onDead.Invoke();
        }
        else
        {
            onHit.Invoke();
        }
    }
}
