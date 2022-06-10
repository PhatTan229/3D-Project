using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Dagger,
    SwordAndShield,
    Bow
}

[System.Serializable]
public class WeaponInformaton
{
    public WeaponType type;
    public GameObject[] parts;
    public RuntimeAnimatorController skill;
    public void ActiveWeapon() => SetWeapon(true);
    public void DisableWeapon() => SetWeapon(false);
    public void SetWeapon(bool isActive)
    {
        for (int i = 0; i < parts.Length; i++)
            parts[i].SetActive(isActive);
    }
}

public class WeaponManager : MonoBehaviour
{
    public Animator anim;
    public WeaponInformaton[] weaponCollection;
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
            //anim.runtimeAnimatorController = daggerController;
            anim.runtimeAnimatorController = weaponCollection[0].skill;
            weaponCollection[0].ActiveWeapon();
            weaponCollection[1].DisableWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //anim.runtimeAnimatorController = swordAndShieldController;
            anim.runtimeAnimatorController = weaponCollection[1].skill;
            weaponCollection[1].ActiveWeapon();
            weaponCollection[0].DisableWeapon();
        }
    }
}
