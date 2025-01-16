using UnityEngine;

public class Bullet : PoolableObject, IDangerable
{
    [SerializeField] private Mover _mover;

    private void Update()
    {
        _mover.Move();
    }
}
