using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum Rarity
{
    Common,
    Rare,
    Legendary
}

public class ItemData : ScriptableObject
{
    [Header("Item")]
    public string Name;
    public Rarity Rarity = Rarity.Common;
    public Sprite Icon;
    public Mesh Model;
}
