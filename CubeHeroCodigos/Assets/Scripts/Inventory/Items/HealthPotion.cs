using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Health Potion", menuName = "Item/Health Potion")]
public class HealthPotion : Item
{
    [Header("Info")] 
    [SerializeField] private int HpRegeneration;
}
