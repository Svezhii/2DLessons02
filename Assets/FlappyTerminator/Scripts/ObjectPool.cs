using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;

    protected Queue<T> _pool;

    public IEnumerable<T> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    protected T GetObject(T prefab)
    {
        T result = _pool.FirstOrDefault(item => item.gameObject.activeSelf == false);

        if (result == null)
        {
            result = Instantiate(prefab, _container);
            result.transform.parent = _container;
            _pool.Enqueue(result);
        }

        return result;
    }

    public void PutObject(T prefub)
    {
        _pool.Enqueue(prefub);
        prefub.gameObject.SetActive(false);
    }

    protected void Reset()
    {
        foreach (var item in _pool)
        {
            item.gameObject.SetActive(false);
        }
    }
}
