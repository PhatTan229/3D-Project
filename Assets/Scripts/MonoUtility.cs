using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoUtility : MonoBehaviour
{
    public static MonoUtility Instance;
    public ConversationController conversation;
    public PlayerManagement player;
    private void Awake() => Instance = this;
    public void ActivePlayer() => SetPlayerState(true);
    public void DisablePlayer() => SetPlayerState(false);
    private void SetPlayerState(bool isActive)
    {
        player.movement.enabled = isActive;
        player.weapon.enabled = isActive;

    }
}
