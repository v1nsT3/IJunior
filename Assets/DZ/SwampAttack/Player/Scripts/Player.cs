using System;
using UnityEngine;
using SwampAttack;
using System.Collections.Generic;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shotPoint;

    private Weapon _currentWeapon;
    private int _currentIndexWeapon = 0;
    private float _currentHealth;
    private Animator _animator;
    private int _money;

    public int Money => _money;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        ChangeWeapon(_weapons[_currentIndexWeapon]);
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _currentWeapon.Shot(_shotPoint);
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke((int)_currentHealth, (int)_maxHealth);

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyChanged?.Invoke(_money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        _money -= weapon.Price;
        MoneyChanged?.Invoke(_money);
        Weapon newWeapon = Instantiate(weapon, transform);
        _weapons.Add(newWeapon);
    }

    public void NextWeapon()
    {
        if (_currentIndexWeapon == _weapons.Count - 1)
            _currentIndexWeapon = 0;
        else
            _currentIndexWeapon++;

        ChangeWeapon(_weapons[_currentIndexWeapon]);
    }

    public void PreviousWeapon()
    {
        if (_currentIndexWeapon == 0)
            _currentIndexWeapon = _weapons.Count - 1;
        else
            _currentIndexWeapon--;

        ChangeWeapon(_weapons[_currentIndexWeapon]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

}
