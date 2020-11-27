using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private uint _distance;
    private uint _coinsCount;

    public float Distance => _distance;
    public float Coins => _coinsCount;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<uint> DistanceChanged;
    public event UnityAction<uint> CoinsChanged;
    public event UnityAction Died;


    private void Start()
    {
        HealthChanged?.Invoke(_health);
        CoinsChanged?.Invoke(_coinsCount);
    }

    private void FixedUpdate()
    {
        _distance++;
        DistanceChanged?.Invoke(_distance);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health<=0)
        {
            Die();
        }
    }

    public void AddCoin()
    {
        _coinsCount++;
        CoinsChanged?.Invoke(_coinsCount);

    }

    public void Die()
    {
        Died?.Invoke();
    }
}
