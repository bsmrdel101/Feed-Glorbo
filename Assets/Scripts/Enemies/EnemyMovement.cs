using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement")]
    private bool isPlayerDetected;
    private float _distance;
    
    [Header("References")]
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private NavMeshAgent _agent;
    private GameObject _playerObj;
    private EnemyData _enemy;

    private void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
        _enemy = _enemyController.Enemy;
        _agent.speed = _enemy.Speed;
        _agent.acceleration = _enemy.Acceleration;
    }

    private void Update()
    {
        GetDistance();
        SeekTarget();
        if (isPlayerDetected) MoveToTarget();
    }

    private void GetDistance()
    {
        _distance = Vector3.Distance(_playerObj.transform.position, transform.position);
    }
    
    private void SeekTarget()
    {
        if (_distance <= _enemy.DetectionRange)
            isPlayerDetected = true;
        else if (_distance >= _enemy.MaxFollowRange)
            isPlayerDetected = false;
    }

    private void MoveToTarget()
    {
        if (_distance > _enemy.MinFollowRange)
            _agent.SetDestination(_playerObj.transform.position);
        else
            _agent.ResetPath();
    }
}
