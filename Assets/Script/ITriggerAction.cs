using UnityEngine;

public interface ITriggerAction
{
    public void OnTriggerEnter(Collider other);
    public void OnTriggerStay(Collider other);
    public void OnTriggerStop(Collider other);
}
