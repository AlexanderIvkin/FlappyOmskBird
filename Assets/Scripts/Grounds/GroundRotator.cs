using UnityEngine;

public class GroundRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Quaternion _startRotation;

    private void Awake()
    {
        _startRotation = transform.rotation;
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.forward, _speed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.rotation = _startRotation;
    }
}
