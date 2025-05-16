using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIReceiver : MonoBehaviour
{
    List<InventoryItem> inventoryItems = new();
    Dictionary<InventoryItem,GameObject> inventoryUI = new();

    [SerializeField] InterfaceReference<IPoolRef> UIItemPrefab;
    [SerializeField] Transform GUI;

    public void UpdateUI(List<InventoryItem> items)
    {
        inventoryItems = items;
        if(GUI.gameObject.activeSelf)
        {
            HideUI();
            ShowUI();
        }
    }

    public void ToggleUI()
    {
        if(GUI.gameObject.activeSelf)
        {
            HideUI();
        }
        else
        {
            ShowUI();
        }
    }

    void ShowUI()
    {
        GUI.gameObject.SetActive(true);
        if (inventoryItems.Count == 0) return;
        inventoryUI.Clear();
        foreach (InventoryItem item in inventoryItems)
        {
            GameObject cash = PoolManager.Instance.Get(UIItemPrefab.Value, Vector3.zero, Quaternion.identity);
            cash.transform.SetParent(GUI);
            cash.GetComponent<InvetoryContainerSetup>().Setup(item);
            inventoryUI.Add(item, cash);
        }
    }

    void HideUI()
    {
        GUI.gameObject.SetActive(false);
        if (inventoryItems.Count == 0) return;
        foreach (InventoryItem item in inventoryUI.Keys)
        {
            PoolManager.Instance.ReturnToPool(UIItemPrefab.Value, inventoryUI[item]);
        }
    }
}
