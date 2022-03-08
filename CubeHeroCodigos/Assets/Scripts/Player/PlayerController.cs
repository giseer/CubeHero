using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")] [SerializeField]
    private int speed;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator; 
        
    private Vector2 _movementDirection;
    private Vector2 _input;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        IsMoving(false);
    }

    private void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movementDirection * speed * Time.deltaTime);
        
    }
    
    /// <summary>
    /// Asigna si el personaje esta en movimiento o no
    /// </summary>
    /// <param name="isMoving"> true = se esta moviendo, false = esta parado</param>
    private void IsMoving(bool isMoving)
    {
        _animator.SetBool("IsMoving", isMoving);
    }

    private void Movement()
    {
        
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_input != Vector2.zero)
        {
            IsMoving(true);
        }
        else
        {
            IsMoving(false);
        }

        if (_input.x !=0)
        {
            _input.y = 0f;
        }
        
        //X
        if (_input.x > 0.1f)
        {
            _movementDirection.x = 1f;
        }
        else if (_input.x < 0f)
        {
            _movementDirection.x = -1f;
        }
        else
        {
            _movementDirection.x = 0f;
        }
        
        //Y
        if (_input.y > 0.1f)
        {
            _movementDirection.y = 1f;
        }
        else if (_input.y < 0f)
        {
            _movementDirection.y = -1f;
        }
        else
        {
            _movementDirection.y = 0f;
        }

        _animator.SetFloat("MoveX", _movementDirection.x);
        _animator.SetFloat("MoveY",_movementDirection.y);
        
    }
    
}
