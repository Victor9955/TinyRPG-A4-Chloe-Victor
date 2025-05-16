using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework.Interfaces;

public interface IPoolRef
{
    public GameObject Prefab {  get; }
}

public interface IPoolInit
{
    void Init();
}


public class PoolManager : SingletonMonobehaviour<PoolManager>
{
    private Dictionary<IPoolRef, Queue<GameObject>> poolDictionary = new ();

    public GameObject Get(IPoolRef poolRef, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(poolRef))
            poolDictionary.Add(poolRef, new Queue<GameObject>());

        Queue<GameObject> pool = poolDictionary[poolRef];

        if (pool.Count == 0)
            CreateNewInstance(poolRef);

        GameObject instance = pool.Dequeue();
        instance.transform.SetPositionAndRotation(position, rotation);
        instance.SetActive(true);
        return instance;
    }

    public void ReturnToPool(IPoolRef poolRef, GameObject instance)
    {
        instance.SetActive(false);
        poolDictionary[poolRef].Enqueue(instance);
    }

    private void CreateNewInstance(IPoolRef poolRef)
    {
        GameObject newInstance = Instantiate(poolRef.Prefab);
        newInstance.SetActive(false);
        newInstance?.GetComponent<IPoolInit>()?.Init();
        poolDictionary[poolRef].Enqueue(newInstance);
    }
}