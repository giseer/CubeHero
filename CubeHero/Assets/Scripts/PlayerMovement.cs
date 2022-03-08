using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables Movimiento")] 
    [SerializeField] private float speed;
    
    private Rigidbody2D _rigidbody2D;

    private bool _isMoving => _movementDirection.magnitude > 0f;
    
    private Vector2 _movementDirection;
    private Vector2 _input;

    public bool IsMoving => _isMoving;
    public Vector2 MovementDirection => _movementDirection;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        MovementCalculation();
    }

    /// <summary>
    /// Este metodo contiene la logica del movimiento del personaje
    /// </summary>
    private void Movement()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_input.x != 0f)
        {
            _input.y = 0;
        }
        
        // X
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
        
        // Y
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
    }

    private void MovementCalculation()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movementDirection * speed * Time.fixedDeltaTime);
    }
    
}
