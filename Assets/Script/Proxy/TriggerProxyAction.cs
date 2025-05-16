using UnityEngine;

public class TriggerProxyAction : MonoBehaviour
{
    [SerializeField] InterfaceReference<ITriggerAction> action;

    private void OnTriggerEnter(Collider other)
    {
        if(!action.IsNull())
        {
            action.Value.IOnTriggerEnter(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!action.IsNull())
        {
            action.Value.IOnTriggerStay(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!action.IsNull())
        {
            action.Value.IOnTriggerStop(other);
        }
    }
}
