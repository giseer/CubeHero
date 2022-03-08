using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeBase : MonoBehaviour
{
    [Header("Variables Vida")] 
    [SerializeField] private int initialHearts;
    [SerializeField] private int maxHearts;
    
    public int Hearts { get; protected set; }

    public static Action KillPlayerEvent;

    private void Start()
    {
        Hearts = initialHearts;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetHealth(1);
        }else if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLife();
        }else if (Input.GetKeyDown(KeyCode.T))
        {
            GetDamage(1);
        }
    }

    public void GetDamage(int damage)
    {
        if (Hearts - damage >= 0)
        {
            Hearts -= damage;
            
        }else if (Hearts - damage < 0)
        {
            Hearts = 0;
        }
 
        if (Hearts == 0)
        {
            KillPlayer();
        }
    }
    
    public void GetHealth(int healValue)
    {

        if (Hearts + healValue <= maxHearts)
        {
            Hearts += healValue;
        }else if (Hearts + healValue > maxHearts)
        {
            Hearts = maxHearts;
        }
    }
    
    public void ResetLife()
    {
        Hearts = maxHearts;
    }

    private void KillPlayer()
    {
        KillPlayerEvent?.Invoke();
    }
}
