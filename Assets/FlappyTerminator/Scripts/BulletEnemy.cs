using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction = Vector3.left;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
