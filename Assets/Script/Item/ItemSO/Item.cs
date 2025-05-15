using System;
using UnityEngine;

[Serializable]
public abstract class Item : IPoolable
{
    [SerializeField] private GameObject _prefab;

    GameObject IPoolable.prefab => _prefab;

    public virtual void HideObject(GameObject gameObject) => gameObject.SetActive(false);

    public virtual void InitializeObject(GameObject gameObject) => throw new NotImplementedException();

    public virtual void ResetObject(GameObject gameObject) => gameObject.SetActive(true);
}
