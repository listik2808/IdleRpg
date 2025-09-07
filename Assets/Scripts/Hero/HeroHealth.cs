using Screpts.Services.PersistenProfress;
using Scripts.Data;
using Scripts.Logic;
using System;
using UnityEngine;

namespace Screpts.Hero
{
    public class HeroHealth : MonoBehaviour,ISavedProgress,IHeath
    {
        private State _state;
        private float _currentHp;
        private float _maxHp;
        public event Action HealthChanged;

        public float Current
        {
            get => _currentHp;
            set
            {
                if(_currentHp != value)
                {
                    _currentHp = value;
                    HealthChanged?.Invoke();
                }
            }
        }
        public float Max 
        {
            get => _maxHp;
            set => _maxHp = value;
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _state = playerProgress.HeroState;
            HealthChanged?.Invoke();
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.HeroState.CurrentHP = Current;
            playerProgress.HeroState.MaxHP = Max;
        }

        public void TakeDamage(float damage)
        {
            if(Current <= 0)
            {
                Current = 0;
            }
            Current -= damage;
        }
    }
}