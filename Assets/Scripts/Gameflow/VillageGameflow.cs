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
    public MinimapCamera minimapCamera;
    public StatusPanel statusPanel;
    public MinimapCompass compass;
    public MissionPanel missionPanel;

    public PathRenderer path;
    public PolygonIcon destinationIcon;

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

    public GameObject daggerIcon;
    public GameObject gate;
    public Boat boat;
    public float completingDelay;

    private bool canEscape = false;

    private void Start()
    {
        //Default
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
        //Indivial

        StartCoroutine(missionPanel.Show("Explore the world"));
        myPlayer.weapon.SetUp(WeaponType.None);
        SetDestination(packageSender.transform);
    }
    //public GameObject[] enemies;

    public void StartShippingTask()
    {
        packageSender.enabled = false;
        packageReceiver.enabled = true;
        StartCoroutine(missionPanel.Show("Ship the package to the village"));
        SetDestination(packageReceiver.transform);
    }
    public void FinishShippingTask()
    {
        packageReceiver.enabled = false;
        storyTeller.enabled = true;
        SetDestination(storyTeller.transform);
    }

    //private IEnumerator PlayTimeline()
    //{
    //    yield return new WaitForSeconds(1f);
    //    director.Play();
    //}
    public void OnVibration()
    {
        mono.thirdPersonCamera.Shake();
    }

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
        currentNumberOfDeadEnemies = 0;
        StartSpawning();
        StartCoroutine(missionPanel.Show("Find a weapon"));
        daggerIcon.SetActive(true);
        SetDestination(daggerIcon.transform);
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
    public void CountEnemyDeath()
    {
        if (canEscape) return;
        currentNumberOfDeadEnemies++;
        if (currentNumberOfDeadEnemies >= targetNumberOfDeadEnemies)
        {
            canEscape = true;
            StartEscapingMission();
        }
    }

    public void StartCombat()
    {
        mono.player.weapon.SetUp(WeaponType.Dagger);
        StartCoroutine(missionPanel.Show("Keep survive"));
        IgnoreDestination();
    }

    private void StartEscapingMission()
    {
        StartCoroutine(missionPanel.Show("Escape to the river side"));
        gate.SetActive(true);
        SetDestination(boat.transform);
    }
    public void FinishEscapingMission()
    {
        mono.player.Teleport(boat.seat.position);
        mono.player.transform.SetParent(boat.transform);
        mono.player.DisablePlayer();
        boat.StartMoving();
        StartCoroutine(missionPanel.Show("Mission complete"));
        IgnoreDestination();
        Invoke(nameof(FinishChapter), completingDelay);
    }
    public void FinishChapter()
    {
        DatabaseController.Instance.data.chapter++;
        
        LoadingScreen.Instance.LoadScene(SceneTheme.Town);
    }
    private void SetDestination(Transform target)
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
