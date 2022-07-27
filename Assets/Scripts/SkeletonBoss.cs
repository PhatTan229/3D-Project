using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBoss : EnemyManagement
{
    public float attackDistance;
    public float combatDistance;
    public float summonDelay;
    public float summonDuration;
    public Animation anima;
    public PlayMakerFSM fsm;
    public CharacterManagement target;
    public Collider swordCollider;
    public TrailRenderer swordTrail;
    public GameObject flamethrower;
    public GameObject dirtEffect;
    public Skeleton skeleton;
    public Transform[] summonPositions;
    private float nextSummonTime;

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
    public void Init()
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
        if (distance <= attackDistance)
        {
            agent.isStopped = true;
            fsm.SendEvent("ATTACK");
        }
    }

    public void Attack()
    {
        DisableWeapon();
        StopBreathingFire();
        if (!target || !target.health.isAlive)
        {
            fsm.SendEvent("FIND");
            return;
        }
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > attackDistance)
        {
            agent.isStopped = false;
            fsm.SendEvent("CHASE");
            return;
        }
        if (distance < combatDistance)
        {
            ActiveWeapon();
            fsm.SendEvent("USE_WEAPON");
            return;
        }
        if (Time.time > nextSummonTime)
        {
            nextSummonTime = Time.time + summonDelay;
            Invoke(nameof(SummonSkeleton), summonDuration);
            fsm.SendEvent("SUMMON_SKELETON");
            return;
        }
        StartBreathingFire();
        fsm.SendEvent("BREATH_FIRE");
    }

    private void ActiveWeapon() => SetWeapon(true);
    private void DisableWeapon() => SetWeapon(false);

    private void SetWeapon(bool isActive)
    {
        swordCollider.enabled = isActive;
        swordTrail.enabled = isActive;
    }
    private void StartBreathingFire() => flamethrower.SetActive(true);
    private void StopBreathingFire() => flamethrower.SetActive(false);
    private void SummonSkeleton()
    {
        foreach (Transform pos in summonPositions)
        {
            Instantiate(skeleton, pos.position, pos.rotation);
            GameObject dirt = Instantiate(dirtEffect, pos.position, Quaternion.identity);
            Destroy(dirt, 5f);
        }
    }

    public Color color;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, attackDistance);
    }
}
