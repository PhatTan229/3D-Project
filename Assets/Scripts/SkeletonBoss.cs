using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBoss : EnemyManagement
{
    public float stoppingDistance;
    public Animation anima;
    public PlayMakerFSM fsm;
    public CharacterManagement target;
    public Collider swordCollider;
    public TrailRenderer swordTrail;
    protected override void RegisterEvent()
    {
        health.onHit.AddListener(() =>
        {
            fsm.SendEvent("HIT");
        });
        health.onDead.AddListener(() =>
        {
            fsm.SendEvent("DEAD");
        });
    }
    public void FindTarget()
    {
        target = MonoUtility.Instance.population.GetRandomTarget(transform.position, Side.Ally);
        if (target != null)
        {
            agent.isStopped = false;
            fsm.SendEvent("CHASE");
        }
    }
    public void UpdateChasing()
    {
        if (!target || !target.health.isAlive)
        {
            fsm.SendEvent("FIND");
            agent.isStopped = true;
            return;
        }
        agent.SetDestination(target.transform.position);
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= stoppingDistance)
        {
            agent.isStopped = true;
            ActiveWeapon();
            fsm.SendEvent("ATTACK");
        }
    }
    public void UpdateAttack()
    {
        if (!target || !target.health.isAlive)
        {
            DisableWeapon();
            fsm.SendEvent("FIND");
            return;
        }
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > stoppingDistance)
        {
            agent.isStopped = false;
            DisableWeapon();
            fsm.SendEvent("CHASE");
        }
    }

    private void ActiveWeapon() => SetWeapon(true);
    private void DisableWeapon() => SetWeapon(false);

    private void SetWeapon(bool isActive)
    {
        swordCollider.enabled = isActive;
        if (swordTrail) swordTrail.enabled = isActive;
    }
}
