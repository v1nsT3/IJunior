using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _forceJump;

    private float _currentSpeed = 0;
    private float _rotationY = -180;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _currentSpeed = _speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _currentSpeed = _speed * Time.deltaTime * -1;
        }
        else
        {
            _currentSpeed = 0;
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody2D.AddForce(transform.up * _forceJump);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(AnimatorPersonController.Params.Attack);
        }

        transform.rotation = Quaternion.Lerp(Quaternion.identity, new Quaternion(0, _rotationY, 0, 0), _currentSpeed >= 0 ? 0 : 1);
        _animator.SetFloat(AnimatorPersonController.Params.Speed, Mathf.Abs(_currentSpeed));
        transform.position += new Vector3(_currentSpeed, 0, 0);
    }
}
