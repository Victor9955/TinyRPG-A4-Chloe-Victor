using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public GameObject prefab;
    public int maxStack = 1;
    public bool isStackable;

    [SerializeReference] // Allows polymorphic serialization
    public Item itemDefinition;
}
