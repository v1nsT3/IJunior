using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;

    public event UnityAction<float> OnChangeHealth;

    private float _currentHealth;

    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealth;


    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Increase(int value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, _minHealth, _maxHealth);
        OnChangeHealth?.Invoke(_currentHealth);
    }

    public void Decrease(int value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - value, _minHealth, _maxHealth);
        OnChangeHealth?.Invoke(_currentHealth);
    }
}
