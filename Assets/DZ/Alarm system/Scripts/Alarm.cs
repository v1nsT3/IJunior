using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private AudioSource _sirenAudio;

    private int _maxVolume = 1;
    private int _minVolume = 0;
    private Coroutine _currentCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            _currentCoroutine = StartCoroutine(StartSiren());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            _currentCoroutine = StartCoroutine(StopSiren());
        }
    }

    private IEnumerator StartSiren()
    {
        _sirenAudio.volume = _minVolume;
        _sirenAudio.Play();

        while (_sirenAudio.volume < _maxVolume)
        {
            _sirenAudio.volume += Time.deltaTime / _delay;
            yield return null;
        }
    }

    private IEnumerator StopSiren()
    {
        while (_sirenAudio.volume > _minVolume)
        {
            _sirenAudio.volume -= Time.deltaTime / _delay;
            yield return null;
        }

        _sirenAudio.Stop();
    }
}
