using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Priest : MonoBehaviour
{
    [System.NonSerialized] public NavMeshAgent agent;
    [System.NonSerialized] public Collider[] enemies;
    public float visonRange;
    public AncientTree tree;
    public UnityEvent arrive;
    public Vector3 startDestination;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        startDestination = transform.position;
    }
    private void Update()
    {
        enemies = Physics.OverlapSphere(transform.position, visonRange, LayerMask.GetMask("Enemy"));
    }

    public void Return()
    {
        anim.SetBool("Cast", false);
        anim.SetTrigger("Done");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visonRange);
    }
}
