using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{  
    [SerializeField] private float maxHealth;
    [SerializeField] private float _healthChangeStep;

    public event UnityAction HealthChanged;
    private float _minHealth;

    public float Health { get; private set;}
    public float MaxHealth { get; private set; }

    private void Awake()
    {
        MaxHealth = maxHealth;
        _minHealth = 0;
        Health = MaxHealth;
    }

    public void ChangeHealth(float coefficient)
    {
        if (Health > 0)
        {
            Health += _healthChangeStep * coefficient;
            Health = Mathf.Clamp(Health, _minHealth, MaxHealth);
            HealthChanged?.Invoke();
        }
    }
}
