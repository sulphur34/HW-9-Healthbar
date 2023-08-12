using UnityEngine;

public class Animations : MonoBehaviour
{    
    private const string Hurt = "Hurt";
    private const string Healed = "Heal";
    private const string IsDead = "isDead";

    [SerializeField] private Player _player;

    private Animator _animator;
    private int _hurtIndex;
    private int _healIndex;
    private int _isDeadIndex;
    private float _currentHealth;

    private void Awake()
    {
        _hurtIndex = Animator.StringToHash(Hurt);
        _healIndex = Animator.StringToHash(Healed);
        _isDeadIndex = Animator.StringToHash(IsDead);
    }

    private void OnEnable()
    {
        _animator = _player.GetComponent<Animator>();
        _player.HealthChanged += OnHealthChange;
    }    

    private void Start()
    {
        _currentHealth = _player.Health;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChange;
    }  

    private void OnHealthChange()
    {
        if(_player.Health == 0)
            _animator.SetBool(_isDeadIndex, true);

        if (_currentHealth < _player.Health)
            _animator.SetTrigger(_healIndex);
        else if (_currentHealth > _player.Health)
            _animator.SetTrigger(_hurtIndex);

        _currentHealth = _player.Health;
    }
}
