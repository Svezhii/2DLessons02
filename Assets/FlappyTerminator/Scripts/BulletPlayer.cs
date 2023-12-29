using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : ObjectPool<Enemy>
{
    [SerializeField] private float _speed;
    private Vector3 _direction;

    private void Update()
    {
        transform.Translate(new Vector3(_direction.x, _direction.y, 0) * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy item))
        {
            gameObject.SetActive(false);
            //item.gameObject.SetActive(false);
            PutObject(item);
        }
    }
}
