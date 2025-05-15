using UnityEngine;

public class TriggerProxyHealth : MonoBehaviour
{
    [SerializeField] EntityHealth _health;

    public void TakeDamage(float damage)
    {
        if (_health == null)
        {
            Debug.LogWarning("Health component not referenced in proxy");
        } else
        {
            _health.TakeDamage(damage);
        }
    }
}
