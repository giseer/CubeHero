using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Gun,
    Potion,
    Scroll,
    Ingredient,
    Treasure
}

public class InventoryItem : ScriptableObject
{
    [Header("Parameters")] 
    public string ID;
    public string Name;
    public Sprite Icon;
    [TextArea] public string Description;

    [Header("Information")] 
    public ItemTypes Type;
    public bool IsConsumable;

}