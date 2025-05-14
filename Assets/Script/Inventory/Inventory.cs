using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    protected List<IItem> items;

    public bool Add(IItem item)
    {
        return false;
    }

    public IItem Drop(int index)
    {
        if (items.Count >= index)
        {
            Drop();
        }
        return items[index];
    }

    public IItem Drop()
    {
        return items[0];
    }

    public List<IItem> DropAll()
    {
        return items;
    }
}
