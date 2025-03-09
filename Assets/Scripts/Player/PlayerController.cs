using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Unity Actions")]
    public static Action<int> DamagePlayerAction;
    
    [Header("Stats")]
    [SerializeField] private int _maxHealth = 12;
    [SerializeField] private int _health = 12;
    
    [Header("Attacks")]
    [SerializeField] private float _attackDuration = 0.2f;
    public Item EquippedItem;
    private bool _canAttack;
    
    [Header("References")]
    [SerializeField] private GameObject _attackHitbox;


    private void OnEnable()
    {
        DamagePlayerAction += DamagePlayer;
    }
    
    private void OnDisable()
    {
        DamagePlayerAction -= DamagePlayer;
    }

    private void Start()
    {
        InventoryManager inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        EquippedItem = inventoryManager.GetEquippedItem();
        _canAttack = true;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _canAttack) MakeAttack();
    }

    private void MakeAttack()
    {
        if (EquippedItem == null) return;
        // TODO: Play animation
        _attackHitbox.SetActive(true);
        StartCoroutine(AttackCooldown());
        StartCoroutine(HitboxDuration());
    }
    
    private void DamagePlayer(int dmg)
    {
        _health = Mathf.Max(0, _health - dmg);
        if (_health <= 0) HandlePlayerDeath();
    }
    
    private void HandlePlayerDeath()
    {
        SceneManager.LoadScene("Game");
    }

    private IEnumerator HitboxDuration()
    {
        yield return new WaitForSeconds(_attackDuration);
        _attackHitbox.SetActive(false);
    }
    
    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(EquippedItem.AttackCooldown);
        _canAttack = true;
    }
}
