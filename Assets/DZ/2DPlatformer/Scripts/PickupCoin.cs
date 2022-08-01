using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private Coin[] _coins;

    private void Awake()
    {
        _coins = GetComponentsInChildren<Coin>();
    }

    private void OnEnable()
    {
        foreach (var coin in _coins)
            coin.OnPickup += PlaySound;
    }

    private void OnDisable()
    {
        foreach (var coin in _coins)
            coin.OnPickup -= PlaySound;
    }

    private void PlaySound()
    {
        if(_sound.isPlaying == true)
        {
            _sound.Stop();
        }

        _sound.Play();
    }
}
