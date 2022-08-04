using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _balance;

    private void OnEnable()
    {
        _player.MoneyChanged += OnBalanceChanged;
        OnBalanceChanged(_player.Money);
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnBalanceChanged;
    }

    private void OnBalanceChanged(int balance)
    {
        _balance.text = balance.ToString();
    }
}
