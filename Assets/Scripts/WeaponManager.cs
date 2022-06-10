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
    public Animator bowAnim;
    //public RuntimeAnimatorController daggerController;
    //public RuntimeAnimatorController swordAndShieldController;
    private void OnValidate() => anim = GetComponent<Animator>();
    private void Start()
    {
        anim.runtimeAnimatorController = weaponCollection[0].skill;
        weaponCollection[0].ActiveWeapon();
        weaponCollection[1].DisableWeapon();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetUp(WeaponType.Dagger);
            anim.runtimeAnimatorController = weaponCollection[0].skill;
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetUp(WeaponType.Bow);
            anim.runtimeAnimatorController = weaponCollection[1].skill;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetUp(WeaponType.SwordAndShield);
            anim.runtimeAnimatorController = weaponCollection[2].skill;
        }
    }
    private void SetUp(WeaponType type)
    {
        for (int i = 0; i < weaponCollection.Length; i++)
        {
            weaponCollection[i].SetUp(i == (int)type);
        }
    }

    public void LoadArrow()
    {
        anim.SetTrigger("Prepare");
        bowAnim.SetTrigger("Load");
    }
    public void ShootArrow()
    {
        anim.SetTrigger("Shoot");
        bowAnim.SetTrigger("Release");
    }
}
