using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private int _currentPoint = 0;
    private int _rotationY = -180;

    private void Start()
    {
        _animator.SetFloat("speed", _speed);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].position, Time.deltaTime * _speed);

        transform.rotation = Quaternion.Lerp(Quaternion.identity, new Quaternion(0, _rotationY, 0, 0), _currentPoint > 0 ? 1 : 0);

        if (transform.position == _points[_currentPoint].position)
        {
            _currentPoint++;

            if(_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
