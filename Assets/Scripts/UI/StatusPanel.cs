using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusPanel : MonoBehaviour
{
    public TMP_Text nameText;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public ArmorBar armorBar;
    private void Start()
    {
        nameText.text = DatabaseController.Instance.data.name;
    }
}
