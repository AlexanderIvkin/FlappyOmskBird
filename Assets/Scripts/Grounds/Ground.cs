using UnityEngine;

public class Ground : MonoBehaviour, IDangerable
{
    [SerializeField] private GroundRotator _groundRotator;

    private void Update()
    {
        _groundRotator.Rotate();
    }
}
