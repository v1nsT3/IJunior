using System.Collections;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private AudioSource _sirenAudio;
    
    private House _house;
    private int _maxVolume = 1;
    private int _minVolume = 0;
    private Coroutine _currentCoroutine;

    private void Awake()
    {
        _house = GetComponentInParent<House>();
    }

    private void OnEnable()
    {
        _house.OnHouseEntered += OnStartSiren;
        _house.OnHouseOuted += OnStopSiren;
    }

    private void OnDisable()
    {
        _house.OnHouseEntered -= OnStartSiren;
        _house.OnHouseOuted -= OnStopSiren;
    }

    public void OnStartSiren()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(PlaySiren(_maxVolume));
    }

    public void OnStopSiren()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(PlaySiren(_minVolume));
    }

    private IEnumerator PlaySiren(int targetVolume)
    {
        if (_sirenAudio.isPlaying == false)
        {
            _sirenAudio.Play();
        }

        while (_sirenAudio.volume != targetVolume)
        { 
            _sirenAudio.volume = targetVolume == _minVolume ?  _sirenAudio.volume - Time.deltaTime / _delay : _sirenAudio.volume + Time.deltaTime / _delay;
            yield return null;
        }

        if (_sirenAudio.volume == _minVolume)
        {
            _sirenAudio.Stop();
        }
    }

}