using UnityEngine;

public class GameObjectPool<T> : ObjectPool<T> where T : IPoolable, new()
{
    private readonly T _prefab;
    private readonly Transform _parent;
    
    public override T Acquire()
    {
        T acquired = base.Acquire();
        acquired.SetActive(true);
        return acquired;
    }

    public override void Release(T releaseObject)
    {
        releaseObject.SetActive(false);
        if (GetPoolSize() > capacity)
        {
            Object.Destroy(releaseObject.gameObject);
            return;
        }
        pool.Enqueue(releaseObject);
    }

    public GameObjectPool(T prefab, Transform parent, bool isWarmedUp)
    {
        _prefab = prefab;
        _parent = parent;
        onCreate = InstantiatePrefab;
        if (isWarmedUp)
        {
            Initialization();
        }
    }

    private T InstantiatePrefab()
    {
        IPoolable newObject = Object.Instantiate(_prefab.gameObject, _parent).GetComponent<IPoolable>();
        return (T)newObject; 
    }
}
