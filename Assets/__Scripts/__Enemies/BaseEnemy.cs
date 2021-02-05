using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamagable<int>
{
    public static Action OnDeath;
    public static Action<int> OnEarnCoins;
    public static Action<int> OnEarnExp;

    [SerializeField]
    private int _coins = 1;
    [SerializeField]
    private int _exp = 1;

    [SerializeField]
    private int _Health;
    public int Health { get { return (_Health); } set { _Health = value; } }

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
        if(Health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        if (OnDeath != null)        OnDeath();
        if (OnEarnCoins != null)    OnEarnCoins(_coins);
        if (OnEarnExp != null)      OnEarnExp(_exp);
    }

    private void OnTriggerEnter(Collider other)
    {
        IAttack<int> attack = other.GetComponent<IAttack<int>>();
        if (attack != null)
        {
            Debug.Log("Hit");
        }
    }

}
