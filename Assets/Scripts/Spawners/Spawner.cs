using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T: PoolableObject
{
    [SerializeField] protected ObjectPool<T> ObjectPool;


    protected virtual void Init(T gettedObject)
    {
        gettedObject.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    }

    public void Spawn(Vector3 position)
    {
        T gettedObject = ObjectPool.Get(position);
        Init(gettedObject);
        gettedObject.Disabled += OnObjectDisable;
        gettedObject.gameObject.SetActive(true);
    }

    protected void OnObjectDisable(PoolableObject disabledObject)
    {
        disabledObject.Disabled -= OnObjectDisable;
        ObjectPool.Release((T)disabledObject);
    }
}
