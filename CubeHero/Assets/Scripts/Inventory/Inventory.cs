using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{

    [SerializeField] private int slotsNum;
    public int SlotsNum => slotsNum;

    [Header("Items")] 
    [SerializeField] private InventoryItem[] itemsInventory;

    private void Start()
    {
        itemsInventory = new InventoryItem[slotsNum];
    }
}
