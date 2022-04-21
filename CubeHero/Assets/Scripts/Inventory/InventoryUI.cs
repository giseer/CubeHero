using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform container;

    private List<InventorySlot> slotsAvailables = new List<InventorySlot>();

    void Start()
    {
        InventoryInit();
    }

    private void InventoryInit()
    {
        for (int i = 0; i < Inventory.Instance.SlotsNum; i++)
        {
            InventorySlot newSlot = Instantiate(slotPrefab, container);
            newSlot.Index = i;
            slotsAvailables.Add(newSlot);
        }
    }
}
