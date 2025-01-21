using UnityEngine;

public class UpLimiter : MonoBehaviour
{
    [SerializeField] private float _upBound;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public void LimitY()
    {
        if (transform.position.y >= _upBound)
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}
