using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class Generic to create pools of objects
public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{

    public static GenericObjectPool<T> Instance { get; private set; }
    

    [SerializeField]
    protected int _MaxNumberOfEntitiesInstantiate = 100;
    [Space(5)]

    [SerializeField]
    protected T _object;
    private Queue<T> _poolObjects = new Queue<T>();

    public void Awake()
    {
        Instance = this;
        AddObject(_MaxNumberOfEntitiesInstantiate);
    }

    public T Get()
    {
        if (_poolObjects.Count == 0) AddObject(1);
        return _poolObjects.Dequeue();

    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        _poolObjects.Enqueue(objectToReturn);
    }

    private void AddObject(int amount)
    {
        for(int i = 0; i < amount; ++i)
        {
            var newObject = GameObject.Instantiate(_object);
            //To keep them contained in their parent container, the pool in this case.
            newObject.transform.parent = this.gameObject.transform;
            newObject.gameObject.SetActive(false);
            _poolObjects.Enqueue(newObject);
        }
    }
}
