using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoUtility : MonoBehaviour
{
    public static MonoUtility Instance;
    public ConversationController conversation;
    public PlayerManagement player;
    public PopulationManager population;
    public MinimapMarkerManager marker;
    public ThirdPersonCamera thirdPersonCamera;
    private void Awake() => Instance = this;
}
