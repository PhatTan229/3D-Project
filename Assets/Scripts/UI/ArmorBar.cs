using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBar : StatBar
{
    public PlayerHealth health;
    public void UpdateArmor()
    {
        UpdateValue(health.Armor, health.maxArmor);
    }

}
