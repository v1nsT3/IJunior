using SwampAttack;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;

    private Weapon _weapon;

    public event UnityAction<WeaponView, Weapon> SellButtonClick;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnSellButtonClick);
        _button.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnSellButtonClick);
        _button.onClick.RemoveListener(TryLockItem);
    }

    public void Init(Weapon weapon)
    {
        _weapon = weapon;
        Render();
    }

    private void Render()
    {
        _label.text = _weapon.Name;
        _price.text = _weapon.Price.ToString();
        _icon.sprite = _weapon.Icon;
    }

    private void OnSellButtonClick()
    {
        SellButtonClick?.Invoke(this, _weapon);
    }

    private void TryLockItem()
    {
        if(_weapon.IsBuyed)
        {
            _button.interactable = false;
        }
    }
}
