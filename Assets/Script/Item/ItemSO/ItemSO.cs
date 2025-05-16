using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject, IPoolRef
{
    public string itemName;
    public GameObject prefab;
    GameObject IPoolRef.Prefab => prefab;
    public Sprite icon;
    public int maxStack = 1;
    public bool isStackable;

    [SerializeReference]
    public Item itemDefinition;

}
