using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private float Damage;
    [SerializeField] private float Armor;
    [SerializeField] private float Speed;
    [SerializeField] private float Level;
    [SerializeField] private float CurrentExp;
    [SerializeField] private float ReqExpNextLevel;
    [Range(0f, 100f)] private float Crit;
    [Range(0f, 100f)] private float Block;
}
