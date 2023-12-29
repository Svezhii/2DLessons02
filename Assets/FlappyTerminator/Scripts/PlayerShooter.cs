using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : ObjectPool<BulletPlayer>
{
    [SerializeField] private BulletPlayer _bullet;


    private Vector3 _playerDirection;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            float playerRotation = transform.eulerAngles.z;
            _playerDirection = new Vector3(Mathf.Cos(playerRotation * Mathf.Deg2Rad), Mathf.Sin(playerRotation * Mathf.Deg2Rad), 0);

            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, 0);

        BulletPlayer bullet = GetObject(_bullet);

        bullet.gameObject.SetActive(true);

        bullet.transform.position = spawnPoint;

        bullet.SetDirection(_playerDirection);
    }
}
