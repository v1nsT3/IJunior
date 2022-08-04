using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _enemySpawner.AllEnemyDied += OnAllEnemyDied;
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _enemySpawner.AllEnemyDied -= OnAllEnemyDied;
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnAllEnemyDied()
    {
        _button.gameObject.SetActive(true);
    }

    private void OnButtonClick()
    {
        _enemySpawner.NextWave();
        _button.gameObject.SetActive(false);
    }
}
