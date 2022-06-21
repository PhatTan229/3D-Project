using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public enum WeaponType
{
    None,
    Dagger,
    Bow,
    SwordAndShield
}

[System.Serializable]
public class WeaponInformaton
{
    public WeaponType type;
    public GameObject[] parts;
    public Collider[] colliders;
    public RuntimeAnimatorController skill;
    public void ActiveWeapon() => SetUp(true);
    public void DisableWeapon() => SetUp(false);
    public void SetUp(bool isActive)
    {
        for (int i = 0; i < parts.Length; i++)
            parts[i].SetActive(isActive);
    }
    //public void StartAttack() => SetAttackState(true);
    //public void StopAttack() => SetAttackState(false);
    public void SetAttackState(bool isAttacking)
    {
        for (int i = 0; i < colliders.Length; i++)
            colliders[i].enabled = isAttacking;
    }
}

public class WeaponManager : MonoBehaviour
{
    public float arrowSpeed;
    public PlayerMovement movement;
    public Animator anim;
    public WeaponInformaton[] weaponCollection;
    public Animator arrowPosAnim;
    public Animator bowAnim;
    public Transform arrowOnHandPos;
    public Rigidbody arrowPrefab;

    public RigBuilder rigBuilder;
    public AimingBehaviour aimingBehaviour;

    public GameObject thirdPersonCamera;
    public GameObject aimingCamera;
    //public RigLayer rigLayer;
    //public RuntimeAnimatorController daggerController;
    //public RuntimeAnimatorController swordAndShieldController;
    private void OnValidate() => anim = GetComponent<Animator>();
    private void Start()
    {
        SetUp(WeaponType.None);
        DisableAiming();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetUp(WeaponType.Dagger);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetUp(WeaponType.Bow);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetUp(WeaponType.SwordAndShield);
        }
    }
    private void SetUp(WeaponType type)
    {
        int weaponIndex = (int)type;
        for (int i = 0; i < weaponCollection.Length; i++)
        {
            weaponCollection[i].SetUp(i == weaponIndex);
            anim.runtimeAnimatorController = weaponCollection[weaponIndex].skill;
        }
    }
    public void SetAttack(WeaponType type, bool isAttacking)
    {
        int weaponIndex = (int)type;
        weaponCollection[weaponIndex].SetAttackState(isAttacking);
    }
    public void StartAttack(WeaponType type) => SetAttack(type, true);
    public void StopAttack(WeaponType type) => SetAttack(type, false);

    public void GetArrow()
    {
        anim.SetTrigger("Prepare");
        SetAimingCamera(true);
    }
    public void LoadArrow() => arrowPosAnim.SetTrigger("Load");
    public void EquipArrow() => bowAnim.SetTrigger("Load");
    public void ShootArrow()
    {
        anim.SetTrigger("Shoot");
        bowAnim.SetTrigger("Release");
        arrowPosAnim.SetTrigger("Shoot");
        Rigidbody arrow = Instantiate(arrowPrefab, arrowOnHandPos.position, arrowOnHandPos.rotation);
        arrow.velocity = arrowOnHandPos.forward * arrowSpeed;
    }

    private void SetAiming(bool aiming)
    {
        rigBuilder.layers[0].active = aiming;
        aimingBehaviour.enabled = aiming;
        movement.enabled = !aiming;
    }
    public void SetAimingCamera(bool aiming)
    {
        thirdPersonCamera.SetActive(!aiming);
        aimingCamera.SetActive(aiming);
    }
    public void ActiveAiming() => SetAiming(true);
    public void DisableAiming() => SetAiming(false);
    public void RecoverBowAndArrowAnimation()
    {
        bowAnim.Play("Take");
        arrowPosAnim.Play("InvisibleArrow");
    }
}
