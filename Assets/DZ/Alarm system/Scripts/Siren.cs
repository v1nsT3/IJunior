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
    }

    private void OnDisable()
    {
        _house.OnEntered -= StartSound;
    }

    public void StartSound(bool isStart)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(PlaySound(isStart ? _maxVolume : _minVolume));
    }

    private IEnumerator PlaySound(int targetVolume)
    {
        if (_sirenAudio.isPlaying == false)
        {
            _sirenAudio.Play();
        }

        while (_sirenAudio.volume != targetVolume)
        {
            _sirenAudio.volume = Mathf.MoveTowards(_sirenAudio.volume, targetVolume, Time.deltaTime / _delay);
            yield return null;
        }

        if (_sirenAudio.volume == _minVolume)
        {
            _sirenAudio.Stop();
        }
    }

}
