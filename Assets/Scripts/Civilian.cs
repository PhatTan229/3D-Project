using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Civilian : MonoBehaviour
{
    public float stoppingDistance;
    public float rotatingSpeed;
    public Animator anim;
    public NavMeshAgent agent;
    private Vector3 destination;
    private void Start() => enabled = false;
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= stoppingDistance)
        {
            SetMovingState(false);
        }
    }
    public void SetDestination(Vector3 _destination)
    {
        destination = _destination;
        agent.SetDestination(_destination);
        SetMovingState(true);
    }
    private void SetMovingState(bool isMoving)
    {
        agent.isStopped = !isMoving;
        anim.SetBool("IsMoving", isMoving);
        enabled = isMoving;
    }
    private IEnumerator Rotate()
    {
        Vector3 direction = MonoUtility.Instance.player.transform.position - transform.position;
        Quaternion desiredDirection = Quaternion.identity;
        do
        {
            float angle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);
            desiredDirection = Quaternion.Euler(0, angle, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredDirection, rotatingSpeed * Time.deltaTime);
            yield return null;
        } while (transform.rotation != desiredDirection);
    }
}
