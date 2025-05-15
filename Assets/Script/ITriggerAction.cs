using UnityEngine;

public interface ITriggerAction
{
    public void IOnTriggerEnter(Collider other);
    public void IOnTriggerStay(Collider other);
    public void IOnTriggerStop(Collider other);
}
