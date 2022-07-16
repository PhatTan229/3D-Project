using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class ZombieTransform : MonoBehaviour
{
    public float delay;
    public bool canTransform;
    public float zombieSpeed;
    public UnityEvent onFinish;
    public Animator anim;
    public NavMeshAgent agent;
    public RuntimeAnimatorController behaviour;
    
    public virtual void StartTransform()
    {
        Invoke(nameof(FinishTransform), delay);
    }

    public virtual void FinishTransform()
    {
        anim.runtimeAnimatorController = behaviour;
        agent.speed = zombieSpeed;
        onFinish.Invoke();
        Destroy(this);
    }
}
