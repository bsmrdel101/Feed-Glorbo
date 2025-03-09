using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public readonly string Name;
    public readonly Sprite Icon;
    public readonly Mesh Model;
    public readonly Rarity Rarity;
    public readonly WeaponType Type;
    public readonly float AttackCooldown;
    public readonly int Dmg;
    private int _qty = 1;

    public Item(ItemData itemData, int qty)
    {
        this.Name = itemData.Name;
        this.Icon = itemData.Icon;
        this.Model = itemData.Model;
        this.Rarity = itemData.Rarity;
        this.SetQty(qty);
        
        WeaponData weaponData = itemData as WeaponData;
        if (weaponData != null)
        {
            this.Type = weaponData.Type;
            this.AttackCooldown = weaponData.AttackCooldown;
            this.Dmg = weaponData.Dmg;
        }
    }
    
    public int Qty()
    {
        return _qty;
    }

    public void SetQty(int amount)
    {
        _qty = amount;
    }
}
