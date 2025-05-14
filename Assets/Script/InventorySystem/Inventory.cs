using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InventoryItem
{
    public ItemSO itemSO;
    public int quantity;

    public InventoryItem(ItemSO itemSO, int quantity)
    {
        this.itemSO = itemSO;
        this.quantity = quantity;
    }
}

public class Inventory : MonoBehaviour, IItemAction
{
    [SerializeField] List<InventoryItem> baseItems = new();

    Dictionary<ItemSO, InventoryItem> items = new();

    [SerializeField] UnityEvent<List<InventoryItem>> OnInventoryUpdate;

    private void Start()
    {
        items.Clear();
        items = baseItems.ToDictionary(item => item.itemSO, item => item);
    }

    public void Execute(ItemSO itemSO)
    {
        if(items.TryGetValue(itemSO, out InventoryItem inventoryItem))
        {
            inventoryItem.quantity++;
        }
        else
        {
            items.Add(itemSO, new InventoryItem(itemSO, 1));
        }
        Debug.Log("Item Added To Inventory");
        OnInventoryUpdate?.Invoke(items.Values.ToList());
    }
}
