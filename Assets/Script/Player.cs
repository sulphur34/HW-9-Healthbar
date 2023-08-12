using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{  
    [SerializeField] private float maxHealth;
    
    private float _minHealth;
    public event UnityAction HealthChanged;

    public float Health { get; private set;}
    public float MaxHealth { get; private set; }

    private void Awake()
    {
        MaxHealth = maxHealth;
        _minHealth = 0;
        Health = MaxHealth;
    }

    public void DecreaseHealth(float increaseValue)
    {
        IncreaseHealthByValue(-increaseValue);
    }

    public void IncreaseHealthByValue(float increaseValue)
    {
        if (Health > 0)
        {
            Health += increaseValue;
            Health = Mathf.Clamp(Health, _minHealth, MaxHealth);
            HealthChanged?.Invoke();
        }
    }    
}
