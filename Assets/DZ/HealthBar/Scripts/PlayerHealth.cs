using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private float _maxHealth = 100;
    private float _minHealth = 0;

    private void Start()
    {
        _healthBar.minValue = _minHealth;
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _maxHealth;
    }

    public void Increase(int value)
    {
        _healthBar.value += value;
    }

    public void Decrease(int value)
    {
        _healthBar.value -= value;
    }
}
