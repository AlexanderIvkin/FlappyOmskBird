using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerRotator _rotator;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private CollisionDetector _collisionDetector;

    public event Action GameOver; 

    private void OnEnable()
    {
        _inputReader.MoveKeyPressed += MoveUp;
        _collisionDetector.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _inputReader.MoveKeyPressed -= MoveUp;
        _collisionDetector.CollisionDetected -= ProcessCollision;
    }

    private void Update()
    {
        MoveDown();
    }

    private void MoveUp()
    {
        _mover.Move();
        _rotator.RotateUp();
    }

    private void MoveDown()
    {
        _rotator.RotateDown();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is IDangerable)
        {
            GameOver?.Invoke();
        }

        if (interactable is IBonusable)
        {
            IBonusable usefull = interactable as IBonusable;

            _scoreCounter.Add(usefull.GetBonusValue());
        }
    }
}
