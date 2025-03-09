using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Unity Actions")]
    public static Action<int> DamageEnemyAction;
    
    [Header("Stats")]
    private int health;
    
    [Header("Attacks")]
    private GameObject _meleeWeapon;
    private bool _canAttack = true;
    
    [Header("References")]
    public EnemyData Enemy;
    private GameObject _playerObj;


    private void OnEnable()
    {
        DamageEnemyAction += DamageEnemy;
    }
    
    private void OnDisable()
    {
        DamageEnemyAction -= DamageEnemy;
    }

    
    private void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
        _meleeWeapon = Enemy.Attack.Model;
        
        health = Enemy.Health;
    }

    private void Update()
    {
        if (!_canAttack) return;
        if (Enemy.Behavior == EnemyBehavior.Melee)
            HandleMeleeAttack();
        else
            HandleRangedAttack();
    }

    private void DamageEnemy(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void HandleMeleeAttack()
    {
        float distance = Vector3.Distance(transform.position, _playerObj.transform.position);
        if (distance > Enemy.Attack.Range) return;
        
        StartCoroutine(AttackCooldown());
        PlayerController.DamagePlayerAction(10);
    }
    
    private void HandleRangedAttack()
    {
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(Enemy.Attack.AttackCooldown);
        _canAttack = true;
    }
}
