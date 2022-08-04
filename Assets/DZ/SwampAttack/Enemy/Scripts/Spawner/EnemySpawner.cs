using SwampAttack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private int _currentWaveIndex = 0;
    private Wave _currentWave;
    private float _timeLastSpawned;
    private int _spawned;
    private int _countEnemyDied;

    public event UnityAction AllEnemyDied;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeLastSpawned += Time.deltaTime;

        if (_timeLastSpawned >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeLastSpawned = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if (_spawned >= _currentWave.Count)
        {
            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Enemy, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint);
        enemy.Init(_player);
        enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _player.AddMoney(enemy.Reward);
        _countEnemyDied++;

        if(_countEnemyDied == _waves[_currentWaveIndex].Count)
        {
            if (_waves.Count > _currentWaveIndex + 1)
                AllEnemyDied?.Invoke();
        }
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        _spawned = 0;
        _countEnemyDied = 0;
        EnemyCountChanged?.Invoke(0, 1);
    }

    public void NextWave()
    {
        SetWave(++_currentWaveIndex);
    }
}
