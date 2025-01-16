using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _currentPosition;

    private void Start()
    {
        _currentPosition = transform.position;
    }

    public void Move()
    {
        _currentPosition += transform.right * _speed * Time.deltaTime;
        transform.position = _currentPosition;
    }
}
