using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private bool start = true;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (start) return;
        InvokeRepeating(nameof(Spawn), 2f,2f);
    }
    private void Start()
    {
        gameObject.SetActive(false);
        start = false;
    }

    private void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }
}
