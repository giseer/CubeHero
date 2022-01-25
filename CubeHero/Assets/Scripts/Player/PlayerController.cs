using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Controls")]
    [SerializeField]private int speed;
    [SerializeField] private float walkDistancePerPulsation = 0.1f;
    
    [Header("Collisions Controls")]
    [SerializeField] private float collisionHitbox;
    
    private Animator _animator;
    
    private Vector2 _input;
    
    private bool _isMoving;

    public LayerMask solidObjectsLayer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _isMoving = false;
    }

    private void Update()
    {
        if (!_isMoving)
        {
            PlayerMovement();
        }
    }

    private void LateUpdate()
    {
        _animator.SetBool("IsMoving", _isMoving);
    }

    private void PlayerMovement()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");

        if (_input != Vector2.zero)
        {
            if (_input.x != 0)
            {
                _input.y = 0f;
            }
            
            _animator.SetFloat("MoveX",_input.x);
            _animator.SetFloat("MoveY", _input.y);

            if (_input.x > 0)
            {
                _input.x = walkDistancePerPulsation;
            }else if (_input.x < 0)
            {
                _input.x = -walkDistancePerPulsation;
            }
            
            if (_input.y > 0)
            {
                _input.y = walkDistancePerPulsation;
            }else if (_input.y < 0)
            {
                _input.y = -walkDistancePerPulsation;
            }
            
            
            var targetPosition = transform.position;
            targetPosition.x += _input.x;
            targetPosition.y += _input.y;

            if (IsAvailable(targetPosition))
            {
                StartCoroutine(MoveTowards(targetPosition));
            }
        }
    }

    private IEnumerator MoveTowards(Vector3 destination)
    {
        _isMoving = true;

        while(Vector3.Distance(transform.position, destination) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
        
        transform.position = destination;
        _isMoving = false;
        
    }

    /// <summary>
    /// El método comprueba que la zona a la que queremos acceder, esté disponible
    /// </summary>
    /// <param name="target">Zona a la que queremos acceder</param>
    /// <returns>Devuelve true, si el target está disponible y false en caso contrario</returns>
    private bool IsAvailable(Vector3 target)
    {
        if (Physics2D.OverlapCircle(target,collisionHitbox, solidObjectsLayer) != null)
        {
            return false;
        }

        return true;
    }
}
