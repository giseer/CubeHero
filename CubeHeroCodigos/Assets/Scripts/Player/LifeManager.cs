using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class LifeManager : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    /// <summary>
    /// Sirve para hacer daño al personaje
    /// </summary>
    /// <param name="damage"> numero de corazones que quita </param>
    public void GetDamage(int damage)
    {
        if (_player.Hearts - damage >= 0)
        {
            _player.Hearts -= damage;

        }else if (_player.Hearts - damage < 0)
        {
            _player.Hearts = 0;
        }
    }

    public void GetHealth(int healValue)
    {

        if (_player.Hearts + healValue <= _player.MaxHearts)
        {
            _player.Hearts += healValue;
        }else if (_player.Hearts + healValue > _player.MaxHearts)
        {
            _player.Hearts = _player.MaxHearts;
        }
    }

    public void ResetLife()
    {
        _player.Hearts = _player.MaxHearts;
    }
}
