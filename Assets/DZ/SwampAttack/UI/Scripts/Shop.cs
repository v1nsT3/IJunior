using SwampAttack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private Transform _container;
    [SerializeField] private Player _player;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            InstantiateWeaponView(_weapons[i]);
        }
    }

    private void InstantiateWeaponView(Weapon weapon)
    {
        WeaponView weaponView = Instantiate(_weaponView, _container);
        weaponView.Init(weapon);
        weaponView.SellButtonClick += OnSellButtonClick;
    }

    private void OnSellButtonClick(WeaponView weaponView, Weapon weapon)
    {
        TrySellWeapon(weaponView, weapon);
    }

    private void TrySellWeapon(WeaponView weaponView, Weapon weapon)
    {
        if (_player.Money >= weapon.Price)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            weaponView.SellButtonClick -= OnSellButtonClick;
        }
    }
}
