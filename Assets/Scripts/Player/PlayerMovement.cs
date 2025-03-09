using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _baseSpeed = 9f;
    [SerializeField] private float _sprintSpeed = 14f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private float _gravity = -90f;
    private float _moveSpeed;
    private float _vertical, _horizontal;
    private Vector3 _velocity;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    private bool _isGrounded;

    [Header("References")]
    [SerializeField] private CharacterController _controller;

    
    private void Start()
    {
        _moveSpeed = _baseSpeed;
    }

    private void Update()
    {
        _isGrounded = CheckGround();
        if (_isGrounded && _velocity.y < 0) _velocity.y = -2f;
        _moveSpeed = Input.GetKey(KeyCode.LeftShift) ? _sprintSpeed : _baseSpeed;
        
        ApplyGravity();
        HandleMovement();
        if (Input.GetButton("Jump") && _isGrounded) HandleJump();
    }

    private void ApplyGravity()
    {
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * x + transform.forward * z;
        movement.Normalize();
        _controller.Move(movement * (_moveSpeed * Time.deltaTime));
    }
    
    private bool CheckGround()
    {
        return Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
    }

    private void HandleJump()
    {
        _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravity);
    }
}
