using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guardian : MonoBehaviour
{
    [System.NonSerialized] public NavMeshAgent agent;
    public Priest priest;
    public Collider weaponCollider;

    public Vector3 startDestination;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        startDestination = transform.position;
    }

    public void Return()
    {
        anim.SetBool("Return", true);
    }
}
