using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterManagement : MonoBehaviour
{
    public Side side;
    public Health health;
    
    public MonoBehaviour[] others;
    private void Start()
    {
        PopulationManager.Instance.pool[side].Add(this);
        health.onDead.AddListener(() =>
        {
            PopulationManager.Instance.pool[side].Remove(this);
        });
    }
}
