using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerFlyer : MonoBehaviour
{
    [SerializeField, Range(3f, 10f)] private float _flyForce;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public void Fly()
    {
        _rigidbody2D.velocity = new Vector2(0, _flyForce);
    }
}