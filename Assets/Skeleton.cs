using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField]private Animator anim;
    public float idleWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
