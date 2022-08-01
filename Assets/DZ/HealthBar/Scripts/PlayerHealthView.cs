using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private PlayerHealth _playerHealth;

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
        _healthBar.value = value;
    }
}
