using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IPoolable> poolable;
    List<GameObject> objects = new();
    List<int> notActive = new();

    public void SpawnObject()
    {
        if (notActive.Count == 0)
        {
            GameObject cash = Instantiate(poolable.Value.prefab);
            poolable.Value.InitializeObject(cash);
            objects.Add(cash);
        }
        else
        {
            poolable.Value.ResetObject(objects[notActive[0]]);
            poolable.Value.InitializeObject(objects[notActive[0]]);
            notActive.RemoveAt(0);
        }
    }
    public void PoolObject(GameObject prefab)
    {
        notActive.Add(objects.IndexOf(prefab));
        poolable.Value.HideObject(prefab);
    }
}