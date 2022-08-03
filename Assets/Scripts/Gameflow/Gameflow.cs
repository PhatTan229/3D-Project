using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Gameflow : MonoBehaviour
{
    public MonoUtility mono;
    public PlayerManagement player;
    public CinemachineVirtualCamera aimingCamera;
    public MinimapCamera minimapCamera;
    public StatusPanel statusPanel;
    public MinimapCompass compass;
    public MissionPanel missionPanel;

    public PathRenderer path;
    public PolygonIcon destinationIcon;
    private void Start()
    {
        Init();
    }
    protected virtual void Init()
    {
        PlayerManagement myPlayer = Instantiate(player, transform.position, transform.rotation);
        mono.player = myPlayer;
        aimingCamera.Follow = myPlayer.transform;
        mono.thirdPersonCamera.target = myPlayer.transform;
        minimapCamera.target = myPlayer.transform;
        myPlayer.weapon.aimingCamera = aimingCamera.gameObject;
        PlayerHealth newHealth = myPlayer.health as PlayerHealth;
        statusPanel.healthBar.health = newHealth;
        statusPanel.armorBar.health = newHealth;
        newHealth.onHealthChanged.AddListener(statusPanel.healthBar.UpdateHealth);
        newHealth.onArmorChanged.AddListener(statusPanel.armorBar.UpdateArmor);
        path.player = myPlayer.transform;
    }

    protected void SetDestination(Transform target)
    {
        path.SetTarget(target);
        destinationIcon.SetPosition(target.position);
    }
    public void IgnoreDestination()
    {
        path.Disable();
        destinationIcon.Disable();
    }

}
