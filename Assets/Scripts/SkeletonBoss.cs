using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBoss : EnemyManagement
{
    public float attackDistance;
    public float combatDistance;
    public Animation anima;
    public PlayMakerFSM fsm;
    public CharacterManagement target;
    public Collider swordCollider;
    public TrailRenderer swordTrail;
    public GameObject flamethrower;
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
        Debug.Log("Init1");
        target = MonoUtility.Instance.population.GetRandomTarget(transform.position, Side.Ally);
        if (target != null)
        {
            Debug.Log($"Init2 {target.gameObject.name}");
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
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            SummonSkeleton();
            fsm.SendEvent("SUMMON_SKELETON");
            return;
        }
        StartBreathingFire();
        fsm.SendEvent("BREATH_FIRE");
    }

    public void BreathFire()
    {

    }
    private void ActiveWeapon() => SetWeapon(true);
    private void DisableWeapon() => SetWeapon(false);

    private void SetWeapon(bool isActive)
    {
        swordCollider.enabled = isActive;
        if (swordTrail) swordTrail.enabled = isActive;
    }
    private void StartBreathingFire() => flamethrower.SetActive(true);
    private void StopBreathingFire() => flamethrower.SetActive(false);
    private void SummonSkeleton() { }

    public Color color;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, attackDistance);
    }
}
