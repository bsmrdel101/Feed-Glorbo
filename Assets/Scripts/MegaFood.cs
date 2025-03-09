using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaFood : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _textObj;
    private GameObject _playerObj;


    private void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        float distance = Vector3.Distance(_playerObj.transform.position, transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance <= 4.5) Collect();
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
        InventoryManager.CollectMegaFoodAction();
        Destroy(gameObject);
    }
}
