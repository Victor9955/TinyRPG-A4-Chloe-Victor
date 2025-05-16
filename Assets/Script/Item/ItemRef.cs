using UnityEngine;

public class ItemRef : MonoBehaviour, ITriggerAction
{
    [SerializeField] ItemSO item;
    public ItemSO Item { get => item; }

    public void IOnTriggerEnter(Collider other)
    {
        PoolManager.Instance.ReturnToPool(item, gameObject);
    }

    public void IOnTriggerStay(Collider other)
    {

    }

    public void IOnTriggerStop(Collider other)
    {

    }
}
