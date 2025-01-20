using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move()
    {
        transform.position += transform.right * _speed * Time.deltaTime;
    }
}
