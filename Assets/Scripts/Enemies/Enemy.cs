using System.Collections;
using UnityEngine;

public class Enemy : PoolableObject, IInteractable ,IDangerable
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private Recharger _recharger;
    
    private EnemyBulletSpawner _bulletSpawner;
    private Coroutine _shotCoroutine;

    public void SetBulletSpawner(EnemyBulletSpawner bulletSpawner)
    {
        _bulletSpawner = bulletSpawner;
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

    public void BehaviourExecute()
    {
        if (_shotCoroutine != null)
            return;

        _shotCoroutine = StartCoroutine(Shot());
    }

    private IEnumerator Shot()
    {
        var wait = new WaitForSeconds(_recharger.Cooldown);

        while (enabled)
        {
            yield return wait;

            if (_recharger.IsRecharge)
            {
                _bulletSpawner.Spawn(_gunPoint.position);
                _recharger.Recharge();
            }
        }

        _shotCoroutine = null;
    }
}
