using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Unity Actions")]
    public static Action<Item, int> AddItemAction;
    public static Action<Item, int> RemoveItemAction;
    public static Action CollectMegaFoodAction;
    
    [Header("Inventory")]
    [SerializeField] private ItemData[] _startingItems;
    private readonly List<Item> _inventory = new List<Item>();
    private Item _equippedItem;
    public int MegaFoods;
    
    [Header("References")]
    [SerializeField] private GameObject _inventoryItemObj;
    [SerializeField] private Transform _hotbarContainer;
    [SerializeField] private MeshFilter _equippedItemModel;


    private void Awake()
    {
        HandleStartingItems();
    }

    private void OnEnable()
    {
        AddItemAction += AddItem;
        RemoveItemAction += RemoveItem;
        CollectMegaFoodAction += CollectMegaFood;
    }
    
    private void OnDisable()
    {
        AddItemAction -= AddItem;
        RemoveItemAction -= RemoveItem;
        CollectMegaFoodAction -= CollectMegaFood;
    }

    public List<Item> Inventory()
    {
        return _inventory;
    }

    private void AddItem(Item item, int qty = 1)
    {
        if (_inventory.Contains(item))
        {
            foreach (Item i in _inventory)
            {
                if (i == item) i.SetQty(i.Qty() + qty);
            }
        }
        else
        {
            item.SetQty(qty);
            _inventory.Add(item);
        }
        UpdateInventory();
    }
    
    private void RemoveItem(Item item, int qty = 1)
    {
        if (_inventory.Contains(item))
        {
            foreach (Item i in _inventory)
            {
                if (i == item) i.SetQty(Mathf.Clamp(i.Qty() - qty, 0, 999));
            }
        }
        else
        {
            _inventory.Remove(item);
        }
        UpdateInventory();
    }

    private void EquipItem(Item item)
    {
        _equippedItem = item;
        _equippedItemModel.mesh = _equippedItem.Model;
        UpdateInventory();
    }

    public Item GetEquippedItem()
    {
        return _equippedItem;
    }
    
    private void HandleStartingItems()
    {
        foreach (ItemData itemData in _startingItems)
        {
            Item item = new(itemData, 1);
            AddItem(item);
        }
        EquipItem(_inventory[0]);
    }

    private void UpdateInventory()
    {
        foreach (Transform child in _hotbarContainer) {
            Destroy(child.gameObject);
        }
        
        foreach (Item item in _inventory)
        {
            GameObject obj = Instantiate(_inventoryItemObj, Vector3.zero, Quaternion.identity);
            InventoryItem inventoryItem = obj.GetComponent<InventoryItem>();
            inventoryItem.SetIcon(item.Icon);
            if (_equippedItem == item)
                inventoryItem.ShowBorder();
            else
                inventoryItem.HideBorder();
            obj.transform.SetParent(_hotbarContainer);
        }
    }

    private void CollectMegaFood()
    {
        MegaFoods += 1;
    }

    public void FeedGlorboMegaFood()
    {
        MegaFoods -= 1;
    }
}
