using UnityEngine;

public class WaveBar : Bar
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private void OnEnable()
    {
        _enemySpawner.EnemyCountChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemyCountChanged -= OnValueChanged;
    }
}
