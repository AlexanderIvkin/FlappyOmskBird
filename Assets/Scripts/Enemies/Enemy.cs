using System.Collections;
using UnityEngine;

public class Enemy : PoolableObject, IInteractable ,IDangerable
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private Recharger _recharger;

    private Shooter _shooter;
    private Coroutine _shotCoroutine;

    private void OnEnable()
    {
        _shotCoroutine = StartCoroutine(Shot());
    }

    private void OnDisable()
    {
        if (_shotCoroutine == null)
            return;

        StopCoroutine(_shotCoroutine);
    }

    private void Update()
    {
        _mover.Move();
    }

    public void CreateShooter(ObjectPool<Bullet> bulletPool)
    {
        Debug.Log("Сделали Шутер");
        _shooter = new Shooter(bulletPool, _gunPoint, _recharger);
    }

    private IEnumerator Shot()
    {
        Debug.Log("Запустили корутину выстрелов врага");
        var wait = new WaitForSeconds(_recharger.Cooldown);

        while (enabled)
        {
            if (_recharger.IsRecharge)
            {
                _shooter.Shot();
            }

            yield return wait;
        }

        yield break;
    }
}
