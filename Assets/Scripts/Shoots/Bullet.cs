using UnityEngine;

public class Bullet : PoolableObject, IInteractable, IDangerable
{
    [SerializeField] protected Mover _mover;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{gameObject.name} столкнулся с {collision.gameObject.name}, хоть паскуда и не должен был");

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
