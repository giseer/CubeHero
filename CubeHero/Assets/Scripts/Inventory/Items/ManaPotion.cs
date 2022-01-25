using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mana Potion", menuName = "Item/Mana Potion")]
public class ManaPotion : Item
{
    [Header("Info")]
    [SerializeField] private int MpRegeneration;
}
