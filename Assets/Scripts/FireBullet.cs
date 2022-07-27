using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public float maxDistance = 7f;

    private void Start()
    {
        Destroy(gameObject, maxDistance / speed);
        Debug.Log($"time to destroy {maxDistance / speed}");
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTrigger {other.name}");
        if (other.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        Debug.Log("destroy");
    }
}
