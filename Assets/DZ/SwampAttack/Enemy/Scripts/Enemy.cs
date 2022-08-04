using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SwampAttack
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _health;
        [SerializeField] private int _reward;

        private Player _player;

        public event UnityAction<Enemy> Died;
        public Player Target => _player;
        public int Reward => _reward;

        public void Init(Player target)
        {
            _player = target;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0)
                Die();
        }

        private void Die()
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}

