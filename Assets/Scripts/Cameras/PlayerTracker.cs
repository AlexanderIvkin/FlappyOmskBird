using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset;

    private void LateUpdate()
    {
        var newPosition = transform.position;
        newPosition.x = _player.transform.position.x + _xOffset;
        transform.position = newPosition;
    }
}
