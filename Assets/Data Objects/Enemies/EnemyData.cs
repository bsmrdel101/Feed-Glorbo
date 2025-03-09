using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyBehavior
{
    Melee,
    Ranged
}

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy", fileName = "Enemy")]
public class EnemyData : ScriptableObject
{
    [Header("Basic")]
    public string Name;
    public int Health = 20;
    public EnemyAttackData Attack;
    
    [Header("Movement")]
    public EnemyBehavior Behavior = EnemyBehavior.Melee;
    public float Speed = 10f;
    public float Acceleration = 13f;
    public float DetectionRange = 25f;
    public float MinFollowRange = 3f;
    public float MaxFollowRange = 60f;
}
