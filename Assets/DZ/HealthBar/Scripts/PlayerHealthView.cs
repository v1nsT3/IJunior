using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _speedChange;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _playerHealth.OnChangeHealth += OnChangeValue;
    }

    private void OnDisable()
    {
        _playerHealth.OnChangeHealth -= OnChangeValue;
    }

    private void Start()
    {
        _healthBar.maxValue = _playerHealth.MaxHealth;
        _healthBar.minValue = _playerHealth.MinHealth;
        _healthBar.value = _playerHealth.MaxHealth;
    }

    private void OnChangeValue(float value)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValueDelay(value));
    }

    private IEnumerator ChangeValueDelay(float value)
    {
        while(_healthBar.value != value)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, value, Time.deltaTime * _speedChange);
            yield return null;
        }
    }
}
