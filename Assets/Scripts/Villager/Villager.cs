using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VillagerWork
{
    Building1, Building2, Building3,
    Cooking1, Cooking2,
    Farming1, Farming2, Farming3,
    Chopping1, Chopping2, Sawing1, Sawing2,
    PickaxeMining, ShovelWorking,
    Fishing
}

public class Villager : MonoBehaviour
{
    public VillagerWork job;
}
