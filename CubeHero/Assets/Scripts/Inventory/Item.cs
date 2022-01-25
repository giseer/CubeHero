using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum ItemCollectionMode
{
    Stackable,
    Unique
}

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private ItemCollectionMode itemCollectionMode;
    [SerializeField] private Image icon;
    [SerializeField] private string name;
    [TextArea][SerializeField] private string description;

    public Item(int id, ItemCollectionMode itemCollectionMode, Image icon, string name, string description)
    {
        this.id = id;
        this.itemCollectionMode = itemCollectionMode;
        this.icon = icon;
        this.name = name;
        this.description = description;
    }

    public override String ToString()
    {
        return "|Id: " + id + " | Collection Mode: " + itemCollectionMode + " | Icon: " + icon + " | Name: " + name +
               " | Description: " + description;
    }

}
