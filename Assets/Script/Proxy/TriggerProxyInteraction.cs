using UnityEngine;

public class TriggerProxyInteraction : MonoBehaviour
{
    [SerializeField] private string tagMask;
    [SerializeField] private GameObject target;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(tagMask) && other.gameObject.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact(target);
        }
    }
}
 