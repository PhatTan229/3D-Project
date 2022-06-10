using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SuitType
{
    Farmer,
    Hunter,
    Knight,
}

[System.Serializable]
public class Suit
{
    public SuitType type;
    public GameObject[] parts;
    public void ActiveSuit() => SetUp(true);
    public void DisableSuit() => SetUp(false);
    public void SetUp(bool enable)
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].SetActive(enable);
        }
    }
}

public class SuitManager : MonoBehaviour
{
    public Suit[] suitCollection;
    public void SetUpSuit(SuitType type)
    {
        for (int i = 0; i < suitCollection.Length; i++)
        {
            suitCollection[i].SetUp(i == (int)type);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetUpSuit(SuitType.Farmer);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetUpSuit(SuitType.Hunter);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetUpSuit(SuitType.Knight);
        }
    }
}
