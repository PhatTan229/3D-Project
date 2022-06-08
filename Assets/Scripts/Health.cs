using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoint;
    public void TakeDamage(int damage)
    {
        healthPoint -= damage;
    }

}
