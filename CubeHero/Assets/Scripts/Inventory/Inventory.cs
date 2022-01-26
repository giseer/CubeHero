using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory:MonoBehaviour
{
    [Header("Items")] 
    [SerializeField] private Item[] items;
    [SerializeField] private Player player;
    [SerializeField] private int slotsNumber = 28;
    
    public int SlotsNumber => slotsNumber;

    private void Start()
    {
        items = new Item[slotsNumber];
    }
}
