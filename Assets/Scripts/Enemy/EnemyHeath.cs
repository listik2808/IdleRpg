using Scripts.Logic;
using System;
using UnityEngine;

namespace Scripts.Enemy
{
    public class EnemyHeath : IHeath
    {
        [SerializeField] private float _current;
        [SerializeField] private float _max;

        public event Action HealthChanged;

        public float Current
        {
            get => _current;
            set => _current = value;
        }

        public float Max
        {
            get => _max;
            set => _max = value;
        }

        public void TakeDamage(float damage)
        {
            if (_current <= 0)
            {
                _current = 0;
            }
            else
            {
                _current -= damage;
                HealthChanged?.Invoke();
            }
        }
    }
}
