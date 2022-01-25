using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerBase _base;
    private int _hearts;
    private int _maxHearts;
    private int _exp;
    private int _reqExpNextLevel;
    private int _stamina;
    private int _maxStamina;
    private LifeManager _lifeManager;
    
    // Setters and Getters
    public int Hearts
    {
        get => _hearts;
        set { _hearts = value; }
    }

    public int MaxHearts
    {
        get => _maxHearts;
        set { _maxHearts = value; }
    }
    // End Setters and Getters

    private void Awake()
    {
        _base = GetComponent<PlayerBase>();
        _lifeManager = GetComponent<LifeManager>();
    }

    private void Start()
    {
        InitPlayer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && _hearts > 0)
        {
            _lifeManager.GetHealth(1);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            _lifeManager.GetDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _lifeManager.ResetLife();
        }
    }

    private void InitPlayer()
    {
        _maxHearts = _base.InitialHearts;
        _hearts = _maxHearts;
        _exp = 0;
        _reqExpNextLevel = _base.ReqExpNextLevel;
        _maxStamina = _base.MaxStamina;
        _stamina = _maxStamina;
    }
}

