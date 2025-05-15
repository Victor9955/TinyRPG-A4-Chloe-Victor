using UnityEngine;

public interface IPoolable
{
    [SerializeField] public GameObject prefab { get; }
    void InitializeObject(GameObject gameObject);
    void HideObject(GameObject gameObject);
    void ResetObject(GameObject gameObject);
}
