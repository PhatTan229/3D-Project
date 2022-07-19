using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDog : EnemyManagement
{
    public float runningAnimationSpeed;
    public float runningSpeed;
    public float minStoppingDistance;
    public float maxStoppingDistance;
    public float stoppingDistance;
    public bool isCasting;
    public Animation anima;
    public PlayMakerFSM fsm;
    public CharacterManagement target;
    public Collider jaw;
    //public Rigidbody rigid;
    protected override void RegisterEvent()
    {
        anima["run"].speed = runningAnimationSpeed;
        health.onHit.AddListener(() => 
        {
            fsm.SendEvent("HIT");
        });
        health.onDead.AddListener(() =>
        {
            if (health.isAlive)
            {
                fsm.SendEvent("DEAD");
            }
        });
    }
    public void FindTarget()
    {
        target = PopulationManager.Instance.GetRandomTarget(transform.position, Side.Ally);
        if (target != null)
        {
            //agent.isStopped = false;
            agent.speed = runningSpeed;
            bool isTargetPlayer = target == MonoUtility.Instance.player;
            stoppingDistance = isTargetPlayer ? maxStoppingDistance : minStoppingDistance;
            fsm.SendEvent("CHASE");
        }
    }
    public void InitData()
    {
        if (isCasting)
        {
            //rigid.isKinematic = false;
            fsm.SendEvent("WALK");
        }
        else
        {
            fsm.SendEvent("START");
        }
    }
    public void UpdateChasing()
    {
        if (!target || !target.health.isAlive)
        {
            //agent.isStopped = true;
            agent.speed = 0;
            fsm.SendEvent("FIND");
            return;
        }
        agent.SetDestination(target.transform.position);
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= stoppingDistance)
        {
            //agent.isStopped = true;
            agent.speed = 0;
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
            //agent.isStopped = false;
            agent.speed = runningSpeed;
            jaw.enabled = false;
            fsm.SendEvent("CHASE");
        }
    }
    
    //public void UpdateWalking()
    //{
    //    rigid.velocity = walkingSpeed * transform.forward;
    //}
    public void StopWalking()
    {
        //rigid.isKinematic = true;
        fsm.SendEvent("WAIT");
    }
    public void StartAttack() => fsm.SendEvent("START");    
    //public void CheckTarget()
    //{
    //    if (!target || !target.health.isAlive) fsm.SendEvent("FIND");
    //}
}
