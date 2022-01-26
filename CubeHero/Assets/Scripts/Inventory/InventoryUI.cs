using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform itemsGrid;

    private Inventory _inventory;
    private List<InventorySlot> availableSlots = new List<InventorySlot>();

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }
    
    private void Start()
    {
        InitInventory();
    }

    private void InitInventory()
    {
        for (int i = 0; i < _inventory.SlotsNumber; i++)
        {
            InventorySlot newSlot = Instantiate(slotPrefab, itemsGrid);
            availableSlots.Add(newSlot);
        }
    }
}
