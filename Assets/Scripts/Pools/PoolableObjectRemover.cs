using UnityEngine;

public class PoolableObjectRemover<T> : MonoBehaviour where T: PoolableObject
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out T pooledObject))
        {
            pooledObject.Disable();
        }
    }
}
