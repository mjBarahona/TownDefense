using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack<T>
{
    T Damage { get; set; }
}
