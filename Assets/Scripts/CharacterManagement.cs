using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterManagement : MonoBehaviour
{
    public Side side;
    public PlayerMovement movement;
    public Health health;
    public WeaponManager weapon;
    public MonoBehaviour[] others;
    private void Start()
    {
        PopulationManager.Instance.pool[side].Add(this);
    }
}
