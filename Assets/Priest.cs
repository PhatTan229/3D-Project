using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Priest : MonoBehaviour
{
    [System.NonSerialized] public NavMeshAgent agent;
    [System.NonSerialized] public Collider[] enemies;
    public float visonRange;
    public AncientTree tree;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        enemies = Physics.OverlapSphere(transform.position, visonRange, LayerMask.GetMask("Enemy"));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visonRange);
    }
}
