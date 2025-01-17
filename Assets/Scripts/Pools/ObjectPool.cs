using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour  where T: PoolableObject
{
    private Transform _parent;
    [SerializeField] private T _prefab;

    private Queue<T> _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public void SetParentObject( Transform parent)
    {
        _parent = parent;
    }

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            T createdObject = Instantiate(_prefab);
            createdObject.transform.parent = _parent;
            return createdObject;
        }

        return _pool.Dequeue();
    }

    public void PutObject(T enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
