using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [System.NonSerialized] public GameObject target;
    [System.NonSerialized] public NavMeshAgent agent;

    public Transform patrolPoint;

    public float idleWaitTime;
    public float waitTime;
    public float patrolRange;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponentInChildren<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            target = null;
        }
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
        anim.SetBool("Patrol", true);
    }
}
