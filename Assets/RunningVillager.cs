using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunningVillager : StateMachineBehaviour
{
    public int runningDistance;
    public int stoppingDistance;
    public LayerMask groundLayer;
    private NavMeshAgent agent;
    private Vector3 destination;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!agent) agent = animator.GetComponent<NavMeshAgent>();
        Vector2 unitCircle = Random.insideUnitCircle * runningDistance;
        Vector3 direction = new Vector3(unitCircle.x, 0, unitCircle.y);
        destination = animator.transform.position + direction;
        if (Physics.OverlapSphere(destination, 0.1f, groundLayer).Length != 0)
        {
            Ray ray = new Ray(destination + 10 * Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hit, groundLayer))
            {
                destination = hit.point;
            }
        }
        agent.SetDestination(destination);
        agent.isStopped = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, destination);
        if (distance <= stoppingDistance)
        {
            animator.SetTrigger("Stop");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.isStopped = true;
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
