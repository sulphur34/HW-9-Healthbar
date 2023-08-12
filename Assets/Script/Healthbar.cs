using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _healthLine;
    [SerializeField] private Player _player;
    [SerializeField] private float _changeStep;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void Start()
    {
        SetStartValues();
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    public void SetStartValues()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.Health;
        _healthLine.color = _gradient.Evaluate(1f);
    }

    public void OnHealthChanged()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(AnimateHealthChange(_player.Health));
    }

    private IEnumerator AnimateHealthChange(float value)
    {
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _changeStep * Time.deltaTime);
            _healthLine.color = _gradient.Evaluate(_slider.normalizedValue);
            yield return null;
        }
    }
}
