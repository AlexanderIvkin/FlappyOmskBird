using UnityEngine;

public class Ground : MonoBehaviour, IInteractable, IDangerable
{
    [SerializeField] private GroundRotator _groundRotator;

    private void Update()
    {
        _groundRotator.Rotate();
    }
}
