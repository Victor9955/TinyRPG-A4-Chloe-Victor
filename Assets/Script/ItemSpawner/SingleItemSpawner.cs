using UnityEngine;

public class SingleItemSpawner : MonoBehaviour
{
    [SerializeField] ItemSO item;
    void Start()
    {
        PoolManager.Instance.Get(item,transform.position,transform.rotation);
    }
}
