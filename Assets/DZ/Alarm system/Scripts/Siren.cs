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
        _house.OnEntered += StartSound;
        _house.OnOuted += StopSound;
    }

    private void OnDisable()
    {
        _house.OnEntered -= StartSound;
        _house.OnOuted -= StopSound;
    }

    public void StartSound()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(PlaySound(_maxVolume));
    }

    public void StopSound()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(PlaySound(_minVolume));
    }

    private IEnumerator PlaySound(int targetVolume)
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
