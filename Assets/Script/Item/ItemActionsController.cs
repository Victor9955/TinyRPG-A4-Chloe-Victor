using NaughtyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemActionsController : MonoBehaviour, IInteractable
{
    [SerializeField] Transform mainTransform;

    public void Interact(GameObject user)
    {
        if(user.TryGetComponent(out ItemRef itemRef))
        {
            mainTransform.GetComponentsInChildren<IItemAction>().ToList().ForEach(item => { item.Execute(itemRef.Item); });
        }
    }

    [Button]
    public void Test()
    {
        Interact(gameObject);
    }
}
