using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    PATROL,
    HUNTING
}
public class Skeleton : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public GameObject target;
    [System.NonSerialized] public NavMeshAgent agent;
    [System.NonSerialized] public float distance;
    public Transform patrolPoint;
    public GameObject player;
    public EnemyState enemyState;

    public float idleWaitTime;
    public float maxPatrolWaitTime;
    public Collider[] targetsAvaiable;
    public float PatrolWaitTime { get { return patrolWaitTime; } set { patrolWaitTime = value; } }
    public float patrolRange;
    public float invasiveRange;
    public float attackRange;
    public float visonRange;

    private float patrolWaitTime;
    private GameObject currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        patrolWaitTime = maxPatrolWaitTime;
        patrolPoint.SetParent(null);
    }

    private void Update()
    {
        //target = GameObject.Find("MalePlayer");       
        if(enemyState == EnemyState.PATROL)
        {
            if (target == null)
            {
                FindTarget();
            }
        }
        if (enemyState == EnemyState.HUNTING)
        {
            InvasiveFindTarget();

        }
        if (target != null)
        {
            distance = Vector3.Distance(agent.transform.position, target.transform.position);
            anim.SetBool("Attack", (int)distance <= (int)attackRange);
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
        var randomX = Random.Range(0, 150);
        var randomZ = Random.Range(10, 150);
        patrolPoint.position = new Vector3(randomZ, patrolPoint.position.y, randomZ);
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
    public void FindTarget()
    {      
        if (enemyState == EnemyState.PATROL)
        {
            var targetsInsight = Physics.OverlapSphere(transform.position, visonRange);
            for (int i = 0; i < targetsInsight.Length; i++)
            {
                if (targetsInsight[i].gameObject.layer == LayerMask.NameToLayer("Ally"))
                {
                    target = targetsInsight[i].gameObject;
                    break;
                }
                else if (targetsInsight[i].gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    target = targetsInsight[i].gameObject;
                }
                else
                {
                    target = null;
                }
            }
        }    
        UpdateDestination();
    }

    public void InvasiveFindTarget()
    {
        float initialRange = invasiveRange;
        int count = 5;
        while (count > 0 && target == null)
        {
            targetsAvaiable = Physics.OverlapSphere(transform.position, invasiveRange, LayerMask.GetMask("Ally"));
            invasiveRange += 2;
            count--;
            if (targetsAvaiable.Length > 0)
            {
                target = targetsAvaiable[0].gameObject;
                invasiveRange = initialRange;
                break ;
            }
        }
        if (target == null)
        {
            target = player;
        }
        currentTarget = target;
        if(!currentTarget.activeInHierarchy)
        {
            target = null;
        }
    }
    private void UpdateDestination()
    {
        if(target == null)
        {
            agent.destination = patrolPoint.transform.position;
        }
        if(target != null)
        {
            agent.destination = target.transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visonRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, invasiveRange);
    }
}
