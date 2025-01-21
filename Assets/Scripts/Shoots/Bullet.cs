using UnityEngine;

public class Bullet : PoolableObject, IInteractable, IDangerable
{
    [SerializeField] protected Mover _mover;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PoolableObject poolableObject))
        {
            poolableObject.Disable();
        }

        Disable();
    }

    private void Update()
    {
        _mover.Move();
    }
}
