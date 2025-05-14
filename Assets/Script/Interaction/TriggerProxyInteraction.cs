using UnityEngine;

public class TriggerProxyInteraction : MonoBehaviour
{
    [SerializeField] private string tagMask;
    [SerializeField] private InterfaceReference<IInteractable> interactable;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(tagMask) && interactable != null)
        {
            interactable.Value.Interact(other.gameObject);
        }
    }
}
