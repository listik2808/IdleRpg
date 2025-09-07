using System;

namespace Scripts.Data
{
    [Serializable]
    public class State
    {
        public float CurrentHP;
        public float MaxHP;
        public float Armor;

        public void ResetHP() => CurrentHP = MaxHP;
    }
}
