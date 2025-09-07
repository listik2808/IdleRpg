using System;

namespace Scripts.Logic
{
    public interface IHeath
    {
        float Current { get; set; }
        float Max { get; set; }

        event Action HealthChanged;

        void TakeDamage(float damage);
    }
}