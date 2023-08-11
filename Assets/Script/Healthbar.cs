using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _healthColor;

    public void SetMaxValue(float value)
    {
        _slider.maxValue = value;
        _slider.value = value;
        _healthColor.color = _gradient.Evaluate(1f);
    }

    public void SetCurrentValue(float value)
    {
        StartCoroutine(AnimateHealthChange(value));
    }

    private IEnumerator AnimateHealthChange(float value)
    {
        float changeStep = 60f;

        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, changeStep * Time.deltaTime);
            _healthColor.color = _gradient.Evaluate(_slider.normalizedValue);
            yield return null;
        }
    }
}
