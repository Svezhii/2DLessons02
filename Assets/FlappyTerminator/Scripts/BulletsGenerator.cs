using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletsGenerator : ObjectPool<BulletEnemy>
{
    [SerializeField] private BulletEnemy _prefab;
    [SerializeField] private float _delay;

    private Coroutine _coroutine;


    private void OnEnable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(GenerateBullets());
    }

    private IEnumerator GenerateBullets()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return waitForSeconds;
        }
    }

    public void StartGenerate()
    {
        StartCoroutine(GenerateBullets());
    }

    private void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        BulletEnemy bullet = GetObject(_prefab);

        bullet.gameObject.SetActive(true);
        bullet.transform.position = spawnPoint;
    }
}
