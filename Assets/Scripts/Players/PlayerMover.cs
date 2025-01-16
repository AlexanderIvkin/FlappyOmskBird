using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField, Range(3f, 10f)] private float _upForce;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public void Move()
    {
        _rigidbody2D.velocity = new Vector2(0, _upForce);
    }
}