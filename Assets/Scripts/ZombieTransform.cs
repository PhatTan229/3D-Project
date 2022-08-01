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
    public GameObject shadowPrefab;
    private GameObject shadowFog;
    public virtual void StartTransform()
    {
        if (MonoUtility.Instance.death.isActive)
            Invoke(nameof(FinishTransform), delay);
        else
            Destroy(gameObject, delay);
    }
    public virtual void FinishTransform()
    {
        anim.runtimeAnimatorController = behaviour;
        agent.speed = zombieSpeed;
        CreateMagicEffect();
        onFinish.Invoke();
        Destroy(this);
    }
    private void CreateMagicEffect()
    {
        shadowFog = Instantiate(shadowPrefab, transform);
        shadowFog.transform.localPosition = new Vector3(0, 1, 0);
    }
}
