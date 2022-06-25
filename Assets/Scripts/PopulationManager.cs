using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    Ally,
    Enemy
}

public class PopulationManager : MonoBehaviour
{
    public static PopulationManager Instance;
    public Dictionary<Side, List<CharacterManagement>> pool;
    private void Awake()
    {
        Instance = this;
        pool = new Dictionary<Side, List<CharacterManagement>>();
        List<CharacterManagement> allyList = new List<CharacterManagement>();
        List<CharacterManagement> enemyList = new List<CharacterManagement>();
        pool.Add(Side.Ally, allyList);
        pool.Add(Side.Enemy, enemyList);
    }
}
