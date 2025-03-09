using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glorbo : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _textObj;
    [SerializeField] private InventoryManager _inventoryManager;
    private GameObject _playerObj;
    
    [Header("Mega Foods")]
    private int _megaFoodsCollected;


    private void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        float distance = Vector3.Distance(_playerObj.transform.position, transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance <= 8.5) Collect();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _textObj.SetActive(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _textObj.SetActive(false);
    }

    private void Collect()
    {
        if (_inventoryManager.MegaFoods == 0) return;
        _inventoryManager.FeedGlorboMegaFood();
        _megaFoodsCollected += 1;
        if (_megaFoodsCollected >= 3)
        {
            // TODO: Handle win
        }
    }
}
