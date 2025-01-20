using UnityEngine;

public class Bullet : PoolableObject, IInteractable, IDangerable
{
    [SerializeField] protected Mover _mover;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Коллизия происходит");

        if (collision.gameObject.TryGetComponent(out PoolableObject poolableObject))
        {
            Debug.Log("Это пуловый объект");
            poolableObject.Disable();
        }

        Disable();
    }

    protected void Update()
    {
        _mover.Move();
    }
}
