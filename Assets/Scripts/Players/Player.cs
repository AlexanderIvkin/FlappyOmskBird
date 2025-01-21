using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerFlyer _mover;
    [SerializeField] private PlayerRotator _rotator;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private ObjectPool<Bullet> _bulletPool;
    [SerializeField] private Recharger _recharger;
    [SerializeField] private PlayerBulletSpawner _playerBulletSpawner;
    [SerializeField] private UpLimiter _upLimiter;

    public event Action GameOvered;

    private void OnEnable()
    {
        _inputReader.FlyKeyPressed += MoveUp;
        _inputReader.ShotKeyPressed += Shot;
        _collisionDetector.TriggerEntered += _collisionHandler.ProcessCollision;
        _collisionHandler.DangerableTouched += GameOver;
        _collisionHandler.ScoreableTouched += _scoreCounter.Add;
    }

    private void OnDisable()
    {
        _inputReader.FlyKeyPressed -= MoveUp;
        _inputReader.ShotKeyPressed -= Shot;
        _collisionDetector.TriggerEntered -= _collisionHandler.ProcessCollision;
        _collisionHandler.DangerableTouched -= GameOver;
        _collisionHandler.ScoreableTouched -= _scoreCounter.Add;
    }

    private void Update()
    {
        RotateDown();
        _upLimiter.LimitY();
    }

    private void MoveUp()
    {
        _mover.Fly();
        _rotator.RotateUp();
    }

    private void RotateDown()
    {
        _rotator.RotateDown();
    }

    private void Shot()
    {
        if (_recharger.IsRecharge)
        {
            _recharger.Recharge();
            _playerBulletSpawner.Spawn(_gunPoint.position);
        }
    }

    private void GameOver()
    {
        GameOvered?.Invoke();
    }
}
