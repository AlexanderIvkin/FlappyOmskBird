using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T: PoolableObject
{
    [SerializeField] protected ObjectPool<T> ObjectPool;


    protected virtual void InitRotation(T gettedObject)
    {
        gettedObject.transform.right = transform.right;
    }

    public void Spawn(Vector3 position)
    {
        T gettedObject = ObjectPool.Get(position);
        InitRotation(gettedObject);
        gettedObject.Disabled += OnObjectDisable;
        gettedObject.gameObject.SetActive(true);
    }

    protected void OnObjectDisable(PoolableObject disabledObject)
    {
        disabledObject.Disabled -= OnObjectDisable;
        ObjectPool.Release((T)disabledObject);
    }
}
