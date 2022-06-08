using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdle : StateMachineBehaviour
{
    private Skeleton skeleton;
    private float lastChanceTime;
    private float initialWaitTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        skeleton = animator.GetComponentInParent<Skeleton>();
        initialWaitTime = skeleton.waitTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time - lastChanceTime > skeleton.idleWaitTime)
        {
            skeleton.ChangeIdleState();
            lastChanceTime = Time.time;
        }
        if (skeleton.target == null)
        {
            skeleton.waitTime -= Time.deltaTime;
            if (skeleton.waitTime <= 0)
            {
                skeleton.SkeletonPatrol();
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        skeleton.waitTime = initialWaitTime;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
