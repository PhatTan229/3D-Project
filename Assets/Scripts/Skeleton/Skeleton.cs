using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [System.NonSerialized] public GameObject target;
    [System.NonSerialized] public NavMeshAgent agent;
    [System.NonSerialized] public float distance;
    public Transform patrolPoint;

    public float idleWaitTime;
    public float maxPatrolWaitTime;
    
    public float PatrolWaitTime { get { return patrolWaitTime; } set { patrolWaitTime = value; } }
    public float patrolRange;
    public float attackRange;

    private float patrolWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponentInChildren<NavMeshAgent>();
        patrolWaitTime = maxPatrolWaitTime;
    }

    private void Update()
    {
        target = GameObject.Find("MalePlayer");       
        if(target != null)
        {
            distance = Vector3.Distance(agent.transform.position, target.transform.position);
            agent.destination = target.transform.position;
            anim.SetBool("Attack", distance <= attackRange);
        }
        Debug.Log(PatrolWaitTime);
    }

    public void ChangeIdleState()
    {
        var r = Random.Range(1, 3);
        if(r == 1)
        {
            anim.SetTrigger("Idle_01");
        }
        if(r == 2)
        {
            anim.SetTrigger("Idle_02");
        }
    }

    public void SkeletonPatrol()
    {
        agent.enabled = true;
        var randomX = Random.Range(-patrolRange, patrolRange);
        var randomZ = Random.Range(-patrolRange, patrolRange);
        patrolPoint.position = new Vector3(randomX,0,randomZ);
        agent.SetDestination(patrolPoint.position);
        agent.stoppingDistance = 0;
        anim.SetBool("Patrol", true);
    }

    public void Chasing()
    {
        agent.SetDestination(target.transform.position);
        agent.stoppingDistance = attackRange;
        anim.SetBool("Patrol", true);
    }

    public void Stun()
    {
        anim.SetTrigger("Stun");
    }
}
