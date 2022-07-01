using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public float delay;
    protected override void Start()
    {
        base.Start();
        onDead.AddListener(() =>
        {
            Destroy(gameObject, delay);
        });
    }
}
