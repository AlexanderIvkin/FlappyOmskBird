using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerRotator _rotator;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private ObjectPool<Bullet> _bulletPool;
    [SerializeField] private Recharger _recharger;

    private Vector2 _startPosition;
    private Shooter _shooter;

    public event Action GameOvered;

    private void Awake()
    {
        _startPosition = transform.position;
        _shooter = new Shooter(_bulletPool, _gunPoint, _recharger);
    }

    private void OnEnable()
    {
        _inputReader.FlyKeyPressed += MoveUp;
        _inputReader.ShotKeyPressed += _shooter.Shot;
        _collisionDetector.CollisionDetected += _collisionHandler.ProcessCollision;
        _collisionHandler.DangerableTouched += GameOver;
        _collisionHandler.BonusableTouched += _scoreCounter.Add;
    }

    private void OnDisable()
    {
        _inputReader.FlyKeyPressed -= MoveUp;
        _inputReader.ShotKeyPressed -= _shooter.Shot;
        _collisionDetector.CollisionDetected -= _collisionHandler.ProcessCollision;
        _collisionHandler.DangerableTouched -= GameOver;
        _collisionHandler.BonusableTouched -= _scoreCounter.Add;
    }

    private void Update()
    {
        RotateDown();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        transform.position = _startPosition;
        _mover.VelocityReset();
    }

    private void MoveUp()
    {
        _mover.Move();
        _rotator.RotateUp();
    }

    private void RotateDown()
    {
        _rotator.RotateDown();
    }

    private void GameOver()
    {
        GameOvered?.Invoke();
    }
}
