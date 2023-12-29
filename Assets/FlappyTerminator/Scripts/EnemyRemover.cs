using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyRemover : ObjectPool<EnemyAndBullets>
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyAndBullets item))
        {
            PutObject(item);
        }
    }
}
