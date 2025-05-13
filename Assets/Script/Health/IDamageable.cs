using UnityEngine;

public interface IDamageable
{
    float CurrentHealth { get; set; }
    void TakeDamage(float amount);
}
