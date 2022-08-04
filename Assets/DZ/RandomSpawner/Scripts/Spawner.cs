using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DZ2dPlatformer;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _timeToSpawn;

    private Transform[] _points;

    private void Start()
    {
        _points = GetComponentsInChildren<Transform>();
        StartCoroutine(CreateEnemyDelay());
    }

    private IEnumerator CreateEnemyDelay()
    {
        foreach(Transform point in _points)
        {
            Instantiate(_enemy, point.position, point.rotation);
            yield return new WaitForSeconds(_timeToSpawn);
        }
    }
}
