using UnityEngine;

public interface IItem
{

}

[CreateAssetMenu(fileName = "ItemBase", menuName = "Scriptable Objects/ItemBase")]
public abstract class ItemFactory : GenericFactory<IItem>
{
    public string ItemName;
    public GameObject ItemPhysicPrefab;
    public GameObject ItemUIPrefab;
}
