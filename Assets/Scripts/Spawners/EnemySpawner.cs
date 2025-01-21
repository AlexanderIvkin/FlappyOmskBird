using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _delay;
    [SerializeField] private EnemyBulletSpawner _bulletSpawner;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    private Coroutine _generateEnemyCoroutine;

    private void Start()
    {
        if (_generateEnemyCoroutine != null)
            return;

        _generateEnemyCoroutine = StartCoroutine(GenereateEnemy());
    }

    protected override void InitRotation(Enemy gettedObject)
    {
        base.InitRotation(gettedObject);

        gettedObject.SetBulletSpawner(_bulletSpawner);
        gettedObject.BehaviourExecute();
    }

    private IEnumerator GenereateEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;

            Spawn(GenerateSpawnPoint());
        }

        _generateEnemyCoroutine = null;
    }

    private Vector3 GenerateSpawnPoint()
    {
        float spawnPositionY = Random.Range(_lowerBound, _upperBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        return spawnPoint;
    }
}
