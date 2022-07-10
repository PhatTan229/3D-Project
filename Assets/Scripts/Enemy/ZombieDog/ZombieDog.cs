using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDog : EnemyManagement
{
    public float runningAnimationSpeed;
    public float stoppingDistance;
    public Animation anima;
    public PlayMakerFSM fsm;
    public CharacterManagement target;
    public Collider jaw;
    protected override void RegisterEvent()
    {
        anima["run"].speed = runningAnimationSpeed;
        health.onHit.AddListener(() => 
        {
            Debug.Log("dog hit");
            fsm.SendEvent("HIT");
        });
        health.onDead.AddListener(() =>
        {
            Debug.Log("dog dead");
            fsm.SendEvent("DEAD");
        });
    }
    public void FindTarget()
    {
        target = PopulationManager.Instance.GetRandomTarget(transform.position, Side.Ally);
        if (target != null)
        {
            fsm.SendEvent("CHASE");
            agent.isStopped = false;
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
            jaw.enabled = true;
            fsm.SendEvent("ATTACK");
        }
    }
    public void UpdateAttack()
    {
        if (!target || !target.health.isAlive)
        {
            jaw.enabled = false;
            fsm.SendEvent("FIND");
            return;
        }
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > stoppingDistance)
        {
            agent.isStopped = false;
            jaw.enabled = false;
            fsm.SendEvent("CHASE");
        }
    }
    public void CheckTarget()
    {
        if (!target || !target.health.isAlive) fsm.SendEvent("FIND");
    }
}
