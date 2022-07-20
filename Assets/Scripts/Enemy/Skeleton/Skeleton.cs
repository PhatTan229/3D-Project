using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public CharacterManagement target;
    [System.NonSerialized] public NavMeshAgent agent;
    [System.NonSerialized] public float distance;
    //public Transform patrolPoint;
    public GameObject player;

    public Collider[] targetsAvaiable;
    public GameObject[] weaponTrailRenderer;
    public float idleWaitTime;
    public float maxPatrolWaitTime;   
    public float PatrolWaitTime { get { return patrolWaitTime; } set { patrolWaitTime = value; } }
    public float patrolRange;
    public float invasiveRange;
    public float attackRange;
    public float visonRange;

    public Collider weaponCollider;
    public LayerMask layerMask;

    private float patrolWaitTime;
    private GameObject currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        patrolWaitTime = maxPatrolWaitTime;
        for (int i = 0; i < weaponTrailRenderer.Length; i++)
        {
            weaponTrailRenderer[i].SetActive(false);
        }
        //if (patrolPoint) patrolPoint.SetParent(null);
    }

    private void Update()
    {    
        InvasiveFindTarget();
        if (target != null && target.health.isAlive)
        {
            distance = Vector3.Distance(agent.transform.position, target.transform.position);
            anim.SetBool("Attack", (int)distance <= (int)attackRange);
        }
    }

    //public void ChangeIdleState()
    //{
    //    var r = Random.Range(1, 3);
    //    if(r == 1)
    //    {
    //        anim.SetTrigger("Idle_01");
    //    }
    //    if(r == 2)
    //    {
    //        anim.SetTrigger("Idle_02");
    //    }
    //}
  

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
    //public void FindTarget()
    //{      
    //    if (enemyState == EnemyState.PATROL)
    //    {
    //        var targetsInsight = Physics.OverlapSphere(transform.position, visonRange);
    //        for (int i = 0; i < targetsInsight.Length; i++)
    //        {
    //            if (targetsInsight[i].gameObject.layer == LayerMask.NameToLayer("Ally"))
    //            {
    //                target = targetsInsight[i].gameObject;
    //                break;
    //            }
    //            else if (targetsInsight[i].gameObject.layer == LayerMask.NameToLayer("Player"))
    //            {
    //                target = targetsInsight[i].gameObject;
    //            }
    //            else
    //            {
    //                target = null;
    //            }
    //        }
    //    }    
    //    UpdateDestination();
    //}

    public void InvasiveFindTarget()
    {
        //float initialRange = invasiveRange;
        //int count = 5;
        //while (count > 0 && target == null)
        //{
        //    targetsAvaiable = Physics.OverlapSphere(transform.position, invasiveRange, layerMask);
        //    invasiveRange += 2;
        //    count--;
        //    if (targetsAvaiable.Length > 0)
        //    {
        //        target = targetsAvaiable[0].gameObject;
        //        invasiveRange = initialRange;
        //        break ;
        //    }
        //}
        //if (target == null)
        //{
        //    target = player;
        //}

        //if(!target)
        //{
        //    target = null;
        //}
        target = MonoUtility.Instance.population.GetRandomTarget(transform.position, Side.Ally);
    }
    //private void UpdateDestination()
    //{
    //    if(target == null)
    //    {
    //        //agent.destination = patrolPoint.transform.position;
    //        Vector2 patrolCircle = patrolRange * Random.insideUnitCircle;
    //        Vector3 direction = new Vector3(patrolCircle.x, 0, patrolCircle.y);
    //        Vector3 destination = transform.position + direction;
    //    }
    //    if(target != null)
    //    {
    //        agent.destination = target.transform.position;
    //    }
    //}

    public void ActiveWeapon() => SetWeaponState(true);
    public void DisableWeapon() => SetWeaponState(false);
    public void SetWeaponState(bool isAttacking)
    {
        weaponCollider.enabled = isAttacking;
    }
   private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visonRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, invasiveRange);
    }
}
