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
    //public static PopulationManager Instance;
    public Dictionary<Side, List<CharacterManagement>> pool;
    private void Awake()
    {
        //Instance = this;
        pool = new Dictionary<Side, List<CharacterManagement>>();
        List<CharacterManagement> allyList = new List<CharacterManagement>();
        List<CharacterManagement> enemyList = new List<CharacterManagement>();
        pool.Add(Side.Ally, allyList);
        pool.Add(Side.Enemy, enemyList);
    }
    public CharacterManagement GetRandomTarget(Vector3 currentPosition, Side targetSide)
    {
        List<CharacterManagement> targetList = pool[targetSide];
        if (targetList.Count == 0) return null;
        CharacterManagement target = targetList[0];
        float minDistance = Vector3.Distance(currentPosition, target.transform.position);
        foreach (CharacterManagement character in targetList)
        {
            float distance = Vector3.Distance(currentPosition, character.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                target = character;
            }
        }
        return target;
    }


}

