using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Transform _startPosition;
    private Transform _currentTargetPosition;
    [SerializeField] private float _speed;

    private void Start()
    {
        _currentTargetPosition = _targetPosition;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            _currentTargetPosition = _currentTargetPosition == _targetPosition ? _startPosition : _targetPosition;
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTargetPosition.position, _speed * Time.deltaTime);
    }
}
