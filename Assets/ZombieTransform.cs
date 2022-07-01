using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieTransform : MonoBehaviour
{
    public float delay;
    public bool canTransform;
    public UnityEvent onFinish;
    public Animator anim;
    public RuntimeAnimatorController behaviour;
    
    public virtual void StartTransform()
    {
        Invoke(nameof(FinishTransform), delay);
    }

    public virtual void FinishTransform()
    {
        anim.runtimeAnimatorController = behaviour;
        onFinish.Invoke();
        Destroy(this);
    }
}
