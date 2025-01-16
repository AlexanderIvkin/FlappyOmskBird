using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool<Enemy> _enemyPool;
    [SerializeField] private ObjectPool<Bullet> _bulletPool;

    private void Awake()
    {
        _enemyPool.SetParentObject(transform);
    }

    private void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    private IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_lowerBound, _upperBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy enemy = _enemyPool.GetObject();

        enemy.transform.position = spawnPoint;
        enemy.transform.right = transform.right;
        enemy.SetBulletPool(_bulletPool);
    }
}
