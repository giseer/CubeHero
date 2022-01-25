using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private int initialHearts = 3;
    [SerializeField] private int reqExpNextLevel = 100;
    [SerializeField] private int maxStamina = 100;

    // Setters and Getters
    public int InitialHearts => initialHearts;
    public int ReqExpNextLevel => reqExpNextLevel;
    public int MaxStamina => maxStamina;
    // End Setters and Getters

}
