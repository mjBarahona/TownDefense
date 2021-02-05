using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{

    [SerializeField] private float _Speed;
    [SerializeField] private float _MaxLifeTime = 5f;
    private Vector3 _Orientation;
    //public GameObjectPool Pool { get { return Pool; }
    //    set
    //    {
    //        if (Pool == null) Pool = value;
    //        else throw new System.Exception("Bad pool use, this only get set once");
    //    }
    //}

    //[SerializeField] private PoolManager poolManager;

    //public GameObject Pool { get { return Pool; }  set { Pool = value; } }

    //public void Shoot(Vector3 target)
    //{
    //    transform.LookAt(target);

    //    this.gameObject.SetActive(true);
    //}



    public void OnEnable()
    {
        transform.LookAt(_Orientation);
        //To avoid a check for all update cycles
        Invoke("ReturnToPool", _MaxLifeTime);   
    }

    private void OnDisable()
    {
        CancelInvoke("ReturnToPool");
    }

    public void Update()
    {
        transform.position += transform.forward * _Speed * Time.deltaTime;
    }

    private void ReturnToPool()
    {
        ShotPool.Instance.ReturnToPool(this);
        //Pool.ReturnToPool(this.gameObject);
    }

    public void SetOrientation(Vector3 orientation)
    {
        _Orientation = orientation;
    }
}
