using System.Collections;
using UnityEngine;

public class Enemy : PoolableObject, IDangerable
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private float _cooldown;

    private ObjectPool<Bullet> _bulletPool;
    private Shooter _shooter;
    private Coroutine _shotCoroutine;


    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _shotCoroutine = StartCoroutine(Shot());
    }

    private void OnDisable()
    {
        StopCoroutine(_shotCoroutine);
    }

    private void Update()
    {
        _mover.Move();
    }

    public void SetBulletPool(ObjectPool<Bullet> bulletPool)
    {
        _bulletPool = bulletPool;
    }

    private void Init()
    {
        _shooter = new Shooter(_bulletPool, _gunPoint);
    }

    private IEnumerator Shot()
    {
        var wait = new WaitForSeconds(_cooldown);

        while (enabled)
        {
            yield return wait;

            _shooter.Shot();
        }
    }
}
