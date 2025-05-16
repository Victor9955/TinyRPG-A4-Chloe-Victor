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

    List<InventoryItem> items = new();

    [SerializeField] UnityEvent<List<InventoryItem>> OnInventoryUpdate;

    private void Start()
    {
        items.Clear();
        items = baseItems;
    }

    public void Execute(ItemSO itemSO)
    {
        if(itemSO.isStackable)
        {
            InventoryItem cash = items.FindAll(item => item.itemSO == itemSO).Find(item => item.itemSO.maxStack > item.quantity);
            if (cash != null)
            {
                cash.quantity++;
            }
            else
            {
                items.Add(new InventoryItem(itemSO, 1));
            }
        }
        else
        {
            items.Add(new InventoryItem(itemSO, 1));
        }

        OnInventoryUpdate?.Invoke(items);
    }
}
