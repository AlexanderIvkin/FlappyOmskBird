using UnityEngine;

public class Shooter
{
    private ObjectPool<Bullet> _bulletPool;
    private Transform _gunPoint;
    private Recharger _recharger;

    public Shooter(ObjectPool<Bullet> bulletPool, Transform gunPoint, Recharger recharger)
    {
        _bulletPool = bulletPool;
        _gunPoint = gunPoint;
        _recharger = recharger;
    }

    public void Shot()
    {
        if (_recharger.IsRecharge)
        {
            _recharger.Recharge();
            Bullet currentBullet = _bulletPool.GetObject();
            
            currentBullet.transform.position = _gunPoint.position;
            currentBullet.transform.right = _gunPoint.transform.right;
        }
    }
}
