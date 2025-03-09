using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy Attack", fileName = "Attack")]
public class EnemyAttackData : ScriptableObject
{
    public int Damage = 3;
    public float AttackCooldown = 1.6f;
    public float Range = 1.5f;
    public GameObject Model;
}
