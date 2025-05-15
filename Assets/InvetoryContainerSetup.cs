using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvetoryContainerSetup : MonoBehaviour, IPoolRef
{
    [SerializeField] TextMeshProUGUI amount;
    [SerializeField] Image icon;

    public GameObject Prefab => gameObject;

    public void Setup(InventoryItem item)
    {
        icon.sprite = item.itemSO.icon;
        amount.text = item.quantity.ToString();
        if(item.itemSO.itemDefinition is IUIColor)
        {
            icon.color = ((IUIColor)item.itemSO.itemDefinition).Color;
        }
    }
}
