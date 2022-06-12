using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Dagger,
    Bow,
    SwordAndShield
}

[System.Serializable]
public class WeaponInformaton
{
    public WeaponType type;
    public GameObject[] parts;
    public RuntimeAnimatorController skill;
    public void ActiveWeapon() => SetUp(true);
    public void DisableWeapon() => SetUp(false);
    public void SetUp(bool isActive)
    {
        for (int i = 0; i < parts.Length; i++)
            parts[i].SetActive(isActive);
    }
}

public class WeaponManager : MonoBehaviour
{
    public Animator anim;
    public WeaponInformaton[] weaponCollection;
    public Animator arrowPosAnim;
    public Animator bowAnim;
    public Transform arrowOnHandPos;
    public AttackingArrow arrowPrefab;
    //public RuntimeAnimatorController daggerController;
    //public RuntimeAnimatorController swordAndShieldController;
    private void OnValidate() => anim = GetComponent<Animator>();
    private void Start()
    {
        SetUp(WeaponType.Dagger);
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
    public void GetArrow() => anim.SetTrigger("Prepare");
    public void LoadArrow() => arrowPosAnim.SetTrigger("Load");
    public void EquipArrow() => bowAnim.SetTrigger("Load");
    public void ShootArrow()
    {
        anim.SetTrigger("Shoot");
        bowAnim.SetTrigger("Release");
        arrowPosAnim.SetTrigger("Shoot");
        Instantiate(arrowPrefab, arrowOnHandPos.position, arrowOnHandPos.rotation);
    }
}
