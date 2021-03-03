using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Probably, this class will become in abstract class
public class BaseEnemy : BaseCharacter, IDamagable<int>
{
    public static Action OnDeath;
    public static Action<int> OnEarnCoins;
    public static Action<int> OnEarnExp;
    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private int _coins = 1;
    [SerializeField]
    private int _exp = 1;

    [SerializeField]
    private readonly int _MaxHealth = 100;
    private int _CurrentHealth;
    public int Health { get; set; }

    //Reset values every time the enemy is active
    private void OnEnable()
    {
        Health = _MaxHealth;
        healthBar.SetMaxHealth(_MaxHealth);
        //TODO: Update UI to show the Health Bar
    }

    private void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        IAttack<int> attack = other.GetComponent<IAttack<int>>();
        if (attack != null)
        {
            TakeDamage(attack.Damage);
        }
    }

    public override void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
        
        if(Health <= 0)
        {
            Death();
        }
        healthBar.UpdateHealth(Health);
    }

    public override void Attack()
    {
        //TODO: firstly, we have to have something to hit...
    }

    public void Death()
    {
        //Events to GameManager
        if (OnDeath != null)        OnDeath();
        if (OnEarnCoins != null)    OnEarnCoins(_coins);
        if (OnEarnExp != null)      OnEarnExp(_exp);

        //Death behaviour in the enemy
        gameObject.SetActive(false);
    }

    
}
