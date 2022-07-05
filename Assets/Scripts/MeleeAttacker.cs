using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : MonoBehaviour
{
    public float distance;
    public Side oppositeSide;
    public Collider weaponCollider;
    public TrailRenderer weaponTrail;
    public CharacterManagement target;
    public void StartAttack() => SetAttack(true);
    public void StopAttack() => SetAttack(false);
    private void SetAttack(bool isAttacking)
    {
        weaponCollider.enabled = isAttacking;
        weaponTrail.enabled = isAttacking;
    }
}
