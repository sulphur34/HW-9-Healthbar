using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetMaxValue(float value)
    {
        _slider.maxValue = value;
        _slider.value = value;
    }

    public void SetCurrentValue(float value)
    {
        StartCoroutine(AnimateHealthChange(value));
    }

    private IEnumerator AnimateHealthChange(float value)
    {
        float changeStep = 80f;

        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, changeStep * Time.deltaTime);
            yield return null;
        }
    }
}
