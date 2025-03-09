using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Melee,
    Ranged
}

[CreateAssetMenu(menuName = "Scriptable Objects/Items/Weapon", fileName = "Weapon")]
public class WeaponData : ItemData
{
    [Header("Weapon")]
    public WeaponType Type;
    public float AttackCooldown = 0.5f;
    public int Dmg;
}
