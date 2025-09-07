using UnityEngine;

namespace Screpts.Hero
{
    public class Attack : MonoBehaviour
    {
        
        private float _damage;
        private float _timePrepareAttack;
        private float _timeAttack;

        public float Damage 
        { 
            get => _damage;
            set => _damage = value;
        }

        public float TimePrepareAttack
        {
            get => _timePrepareAttack;
            set => _timePrepareAttack = value;
        }
    }
}