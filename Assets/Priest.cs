using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Priest : MonoBehaviour
{
    [System.NonSerialized] public NavMeshAgent agent;
    public float visonRange;
    public AncientTree tree;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
