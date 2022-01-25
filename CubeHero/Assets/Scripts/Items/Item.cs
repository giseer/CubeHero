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
    [SerializeField] private Image Icon;
    [SerializeField] private string name;
    [TextArea][SerializeField] private string description;

}
