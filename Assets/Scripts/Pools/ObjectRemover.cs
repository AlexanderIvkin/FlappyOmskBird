using UnityEngine;

public class ObjectRemover<T> : MonoBehaviour where T: PoolableObject
{
    [SerializeField] private ObjectPool<T> _pool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out T pooledObject))
        {
            _pool.PutObject(pooledObject);
        }
    }
}
