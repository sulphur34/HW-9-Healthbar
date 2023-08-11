using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const string Hurt = "Hurt";
    private const string Heal = "Heal";
    private const string IsDead = "isDead";

    [SerializeField] private Healthbar _healthbar;
        
    private float _health;
    private float _maxHealth;
    private Animator _animator;
    private int _hurtIndex;
    private int _healIndex;
    private int _isDeadIndex;
    private float _healthChangeStep;

    public float MaxHealth { get; private set; }
    public float Health { get; private set;}

    private void Awake()
    {
        _maxHealth = 100;
        _health = _maxHealth;
        _healthbar.SetMaxValue(_maxHealth);
        _animator = GetComponent<Animator>();
        _hurtIndex = Animator.StringToHash(Hurt);
        _healIndex = Animator.StringToHash(Heal);
        _isDeadIndex = Animator.StringToHash(IsDead);
        _healthChangeStep = 20;
    }

    public void Damage()
    {
        if (_animator.GetBool(_isDeadIndex) == false)
        {
            _animator.SetTrigger(_hurtIndex);

            if (_health >= _healthChangeStep)
            {
                _health -= _healthChangeStep;
            }
            else
            {
                _health = 0;
                _animator.SetBool(_isDeadIndex, true);
            }

            _healthbar.SetCurrentValue(_health);
        }
    }

    public void CastHeal()
    {
        if (_animator.GetBool(_isDeadIndex) == false)
        { 
            _animator.SetTrigger(_healIndex);

            if (_health <= (_maxHealth - _healthChangeStep))
                _health += 10;
            else if (_health < _maxHealth)
                _health = _maxHealth;

            _healthbar.SetCurrentValue(_health);
        }    
    }
}
