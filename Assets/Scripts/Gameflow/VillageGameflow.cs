using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VillageGameflow : MonoBehaviour
{
    public MonoUtility mono;
    public PlayerManagement player;
    public CinemachineVirtualCamera aimingCamera;
    public ThirdPersonCamera thirdPersonCamera;
    public MinimapCamera minimapCamera;
    public StatPanel statPanel;
    public MinimapCompass compass;
    private void Start()
    {
        PlayerManagement myPlayer = Instantiate(player, transform.position, Quaternion.identity);
        mono.player = myPlayer;
        aimingCamera.Follow = myPlayer.transform;
        thirdPersonCamera.target = myPlayer.transform;
        minimapCamera.target = myPlayer.transform;
        compass.thirdPersonCamera = thirdPersonCamera.transform;
        myPlayer.movement.thirdPersonCamera = thirdPersonCamera.transform;
        myPlayer.weapon.thirdPersonCamera = thirdPersonCamera.gameObject;
        myPlayer.weapon.aimingCamera = aimingCamera.gameObject;
        PlayerHealth newHealth = myPlayer.health as PlayerHealth;
        statPanel.healthBar.health = newHealth;
        statPanel.armorBar.health = newHealth;
        newHealth.onHealthChanged.AddListener(statPanel.healthBar.UpdateHealth);
        newHealth.onArmorChanged.AddListener(statPanel.armorBar.UpdateArmor);
    }

    //For demo only
    public GameObject[] enemies;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy) enemy.SetActive(true);
            }
        }
    }

}
