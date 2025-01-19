using UnityEngine;

public class Bullet : PoolableObject, IInteractable, IDangerable
{
    [SerializeField] protected Mover _mover;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Disable();
    }

    protected void Update()
    {
        _mover.Move();
    }
}
