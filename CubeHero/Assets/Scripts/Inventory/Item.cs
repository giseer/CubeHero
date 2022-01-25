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
    [Header("Paramaters")]
    [SerializeField] private int id;
    [SerializeField] private Sprite icon;
    [SerializeField] private string name;
    [TextArea][SerializeField] private string description;
    
    [Header("General Information")]
    [SerializeField] private ItemCollectionMode itemCollectionMode;
    

    public override String ToString()
    {
        return "|Id: " + id + " | Collection Mode: " + itemCollectionMode + " | Icon: " + icon + " | Name: " + name +
               " | Description: " + description;
    }

}
