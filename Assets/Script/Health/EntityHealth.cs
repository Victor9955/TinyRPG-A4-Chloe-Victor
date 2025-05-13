using System;
using UnityEngine;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float _initialHealth = 2.0f;


    private bool _isDead = false;
    private float _currentHealth;

    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }

    public event Action<float, float> OnHealthChanged;
    public event Action OnDeath;

    [SerializeField] UnityEvent _onDamage;
    [SerializeField] UnityEvent _onDeath;

    private void Awake()
    {
        _currentHealth = _initialHealth;
    }

    public void TakeDamage(float amount)
    {
        float oldValue = CurrentHealth;
        CurrentHealth = Mathf.Max(oldValue - amount,0f);

        OnHealthChanged?.Invoke(oldValue,CurrentHealth);
        _onDamage.Invoke();

        if (CurrentHealth < 0f && !_isDead)
        {
            _isDead = true;
            OnDeath?.Invoke();
            _onDeath.Invoke();
        }
    }
}
