using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendWeapon : MonoBehaviour
{
    public int armor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<AttackWeapon>(out AttackWeapon weapon))
        {
            weapon.ReduceDamage(armor);
        }
    }

}
