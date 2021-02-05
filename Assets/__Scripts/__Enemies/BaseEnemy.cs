using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamagable<int>
{
    public static Action OnDeath;
    public static Action<int> OnEarnCoins;
    public static Action<int> OnEarnExp;

    public int _coins = 1;
    public int _exp = 1;

    public int Health { get; set; }

    public void Damage(int damageAmount)
    {
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

    
}
