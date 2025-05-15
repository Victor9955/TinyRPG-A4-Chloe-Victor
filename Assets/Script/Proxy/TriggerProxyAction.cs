using UnityEngine;

public class TriggerProxyAction : MonoBehaviour
{
    [SerializeField] InterfaceReference<ITriggerAction> action;

    private void OnTriggerEnter(Collider other)
    {
        if(!action.IsNull())
        {
            action.Value.OnTriggerEnter(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!action.IsNull())
        {
            action.Value.OnTriggerStay(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!action.IsNull())
        {
            action.Value.OnTriggerStop(other);
        }
    }
}
