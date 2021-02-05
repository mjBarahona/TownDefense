using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour, IAttack<int>
{

    [SerializeField] private float _Speed;
    [SerializeField] private float _MaxLifeTime = 5f;
    public int Damage { get; set; }
    

    private Vector3 _Orientation;



    public void OnEnable()
    {
        transform.LookAt(_Orientation);
        //To avoid a check for all update cycles
        Invoke("ReturnToPool", _MaxLifeTime);   
    }

   
    private void OnDisable()
    {
        //To avoid call after re-active the gameobject
        CancelInvoke("ReturnToPool");
    }

    public void Update()
    {
        transform.position += transform.forward * _Speed * Time.deltaTime;
    }

    private void ReturnToPool()
    {
        ShotPool.Instance.ReturnToPool(this);
    }

    public void SetOrientation(Vector3 orientation)
    {
        _Orientation = orientation;
    }
}
