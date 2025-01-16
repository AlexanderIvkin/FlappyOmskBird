using UnityEngine;

public class Shooter 
{
    private ObjectPool<Bullet> _bulletPool;
    private Transform _gunPoint;

    public Shooter(ObjectPool<Bullet> bulletPool, Transform gunPoint)
    {
        _bulletPool = bulletPool;
        _gunPoint = gunPoint;
    }

    public void Shot()
    {
        Bullet currentBullet = _bulletPool.GetObject();
        currentBullet.transform.parent = _gunPoint;
        currentBullet.transform.right = _gunPoint.transform.right;
    }
}
