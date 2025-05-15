using UnityEngine;

public interface IPhysicalItem : IItem
{
    GameObject ItemPhysicPrefab { get; }
}

public interface IUIItem : IItem
{
    GameObject ItemUIPrefab { get; }
}

public interface IItem
{
    string ItemName { get; }
}

public abstract class ItemBase : ScriptableObject, IUIItem, IPhysicalItem
{
    [SerializeField] private string itemName;

    public string ItemName { get => itemName; }
    public GameObject ItemPhysicPrefab { get => new GameObject("NullItem"); }
    public GameObject ItemUIPrefab { get => new GameObject("NullItem"); }
}

public class NullItem : ItemBase
{ 
    public string ItemName { get => "NullItem"; }
    public GameObject ItemPhysicPrefab { get => new GameObject("NullItem"); }
    public GameObject ItemUIPrefab { get => new GameObject("NullItem"); }
}

public abstract class ItemFactory : GenericFactory<IItem>
{
    [SerializeField] protected InterfaceReference<IItem> item;

    public override IItem CreateType()
    {
        if(item == null)
        {
            return new NullItem();
        }
        return CreateInstance();
    }

    public abstract IItem CreateInstance();
}

public class ItemUIFactory : ItemFactory
{
    public override IItem CreateInstance()
    {
        return new NullItem();
    }
}
