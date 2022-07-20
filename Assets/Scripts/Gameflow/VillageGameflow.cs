using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class VillageGameflow : MonoBehaviour
{
    public MonoUtility mono;
    public PlayerManagement player;
    public CinemachineVirtualCamera aimingCamera;
    public ThirdPersonCamera thirdPersonCamera;
    public MinimapCamera minimapCamera;
    public StatusPanel statusPanel;
    public MinimapCompass compass;
    public MissionPanel missionPanel;

    public PlayableDirector director;
    public SpeakingBehaviour packageSender;
    public SpeakingBehaviour packageReceiver;
    public SpeakingBehaviour storyTeller;

    public Villager[] villagers;

    public Transform[] spawningPositions;
    public EnemyManagement[] enemies;
    public float spawningDuration;
    public int maxNumberOfEnemies;

    public int targetNumberOfDeadEnemies;
    private int currentNumberOfDeadEnemies;

    private void Start()
    {
        //Default
        PlayerManagement myPlayer = Instantiate(player, transform.position, transform.rotation);
        mono.player = myPlayer;
        aimingCamera.Follow = myPlayer.transform;
        thirdPersonCamera.target = myPlayer.transform;
        minimapCamera.target = myPlayer.transform;
        compass.thirdPersonCamera = thirdPersonCamera.transform;
        myPlayer.movement.thirdPersonCamera = thirdPersonCamera.transform;
        myPlayer.weapon.thirdPersonCamera = thirdPersonCamera.gameObject;
        myPlayer.weapon.aimingCamera = aimingCamera.gameObject;
        PlayerHealth newHealth = myPlayer.health as PlayerHealth;
        statusPanel.healthBar.health = newHealth;
        statusPanel.armorBar.health = newHealth;
        newHealth.onHealthChanged.AddListener(statusPanel.healthBar.UpdateHealth);
        newHealth.onArmorChanged.AddListener(statusPanel.armorBar.UpdateArmor);

        //Indivial
        StartCoroutine(missionPanel.Show("Explore the world"));
        
    }
    //public GameObject[] enemies;

    public void StartShippingTask()
    {
        packageSender.enabled = false;
        packageReceiver.enabled = true;
        StartCoroutine(missionPanel.Show("Ship the package to the village"));
    }
    public void FinishShippingTask()
    {
        packageReceiver.enabled = false;
        storyTeller.enabled = true;
    }

    //private IEnumerator PlayTimeline()
    //{
    //    yield return new WaitForSeconds(1f);
    //    director.Play();
    //}
    public void OnBossAppear()
    {
        director.Play();
    }

    public void OnInvasionStart()
    {
        foreach (Villager villager in villagers)
        {
            villager.OnInvasionStart();
        }
        StartCoroutine(missionPanel.Show("Find a weapon"));
        currentNumberOfDeadEnemies = 0;
        StartSpawning();
    }
    public void ActivePlayer() => mono.player.ActivePlayer();
    public void DisablePlayer() => mono.player.DisablePlayer();
    private void StartSpawning()
    {
        foreach(Transform trans in spawningPositions)
        {
            Instantiate(enemies.GetRandomElement(), trans.position, Quaternion.identity);
        }
        Invoke(nameof(SpawnEnemy), spawningDuration);
    }
    private void SpawnEnemy()
    {
        if (mono.population.pool[Side.Enemy].Count <= maxNumberOfEnemies)
        {
            Vector3 position = spawningPositions.GetRandomElement().position;
            EnemyManagement enemy = Instantiate(enemies.GetRandomElement(), position, Quaternion.identity);
            enemy.health.onDead.AddListener(CountEnemyDeath);
        }
        Invoke(nameof(SpawnEnemy), spawningDuration);
    }
    private void CountEnemyDeath()
    {
        currentNumberOfDeadEnemies++;
        if (currentNumberOfDeadEnemies >= targetNumberOfDeadEnemies)
            StartEscapingMission();
    }

    public void StartCombat()
    {
        mono.player.weapon.SetUp(WeaponType.Dagger);
        StartCoroutine(missionPanel.Show("Keep survive"));
    }

    private void StartEscapingMission()
    {
        StartCoroutine(missionPanel.Show("Escape to the river side"));
    }
    private void FinishEscapingMission()
    {
        StartCoroutine(missionPanel.Show("Mission Complete"));
    }

}
