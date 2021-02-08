using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{

    [SerializeField]
    protected string _Name;
    [SerializeField]
    protected float _Damage;
    [SerializeField]
    protected float _AttackSpeed;
    [SerializeField]
    protected GameObject _Prefab;

    public abstract void TakeDamage(int damageAmount);
    public abstract void Attack();

}
