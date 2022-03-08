using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Variables Animaciones")] [SerializeField]
    private string idleLayer;

    [SerializeField] private string moveLayer;

    private Animator _animator;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        LayerUpdate();
        AnimationSwitch();
    }

    private void AnimationSwitch()
    {
        if (!_playerMovement.IsMoving)
        {
            return;
        }

        _animator.SetFloat("X", _playerMovement.MovementDirection.x);
        _animator.SetFloat("Y", _playerMovement.MovementDirection.y);
    }

    private void LayerSwitch(string layerName)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }
        _animator.SetLayerWeight(_animator.GetLayerIndex(layerName), 1);
    }

    private void LayerUpdate()
    {
        if (_playerMovement.IsMoving)
        {
            LayerSwitch(moveLayer);
        }
        else
        {
            LayerSwitch(idleLayer);
        }
    }

    private void KillPlayerReply()
    {
        if (_animator.GetLayerWeight(_animator.GetLayerIndex(idleLayer))==1)
        {
            _animator.SetBool("Dead", true);
        }
    }
    
    private void OnEnable()
    {
        LifeBase.KillPlayerEvent += KillPlayerReply;
    }

    private void OnDisable()
    {
        LifeBase.KillPlayerEvent -= KillPlayerReply;
    }
}