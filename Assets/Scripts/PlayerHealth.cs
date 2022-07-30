using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    
    public float maxArmor;
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
    private bool isImmune = false;
    public float immuneDuration;
    protected override void Start()
    {
        base.Start();
        Armor = maxArmor;
        isImmune = false;
    }

    public override void TakeDamage(float damage)
    {
        if (isImmune) return;
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
            StartImmune();
        }
    }
    private void StartImmune()
    {
        isImmune = true;
        Invoke(nameof(StopImmune), immuneDuration);
    }
    private void StopImmune() => isImmune = false;
}
