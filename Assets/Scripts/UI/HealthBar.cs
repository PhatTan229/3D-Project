using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : StatBar
{
    public PlayerHealth health;
    public void UpdateHealth()
    {
        UpdateValue(health.HealthPoint, health.maxHealthPoint);
    }
}
