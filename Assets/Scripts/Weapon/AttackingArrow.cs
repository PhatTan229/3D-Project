using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingArrow : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{gameObject.name} touch {other.gameObject.name}");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{gameObject.name} collsition {collision.collider.gameObject.name}");
    }

}
