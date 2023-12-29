 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : ObjectPool<Enemy>
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    private void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    private IEnumerator GenerateEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return waitForSeconds;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_lowerBound, _upperBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, 0);

        Enemy enemy = GetObject(_prefab);

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
