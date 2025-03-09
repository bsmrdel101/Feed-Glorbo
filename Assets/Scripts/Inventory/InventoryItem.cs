using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _border;


    public void SetIcon(Sprite sprite)
    {
        _icon.sprite = sprite;
    }

    public void ShowBorder()
    {
        _border.SetActive(true);
    }
    
    public void HideBorder()
    {
        _border.SetActive(false);
    }
}
