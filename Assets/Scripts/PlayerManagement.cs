using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : CharacterManagement
{
    public PlayerMovement movement;
    public WeaponManager weapon;
    public CharacterController controller;
    public void ActivePlayer() => SetPlayerState(true);
    public void DisablePlayer() => SetPlayerState(false);
    private void SetPlayerState(bool isActive)
    {
        movement.enabled = isActive;
        weapon.enabled = isActive;
        controller.enabled = isActive;
    }
    public void Teleport(Vector3 destination)
    {
        transform.position = destination;
    }
}
