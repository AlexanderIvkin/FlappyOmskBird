using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour  where T: PoolableObject
{
    [SerializeField] private T _prefab;

    private Queue<T> _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public T Get(Vector3 positon)
    {
        T newPoolableObject;

        if (_pool.Count > 0)
        {
            newPoolableObject = _pool.Dequeue();
        }
        else
        {
            newPoolableObject = CreateObject(_prefab);
        }

        newPoolableObject.transform.position = positon;

        return newPoolableObject;
    }

    private T CreateObject(T prefab)
    {
        return Instantiate(prefab);
    }

    public void Release(T poolableObject)
    {
        _pool.Enqueue(poolableObject);
    }
}
