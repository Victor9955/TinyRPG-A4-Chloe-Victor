using UnityEngine;

public class ItemRef : MonoBehaviour
{
    [SerializeField] ItemSO item;
    public ItemSO Item { get => item; }
}
