using UnityEngine;
using Weapons;

namespace Screpts.Hero
{
    public class RightHandSlot : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        public Weapon Weapon => _weapon;

        public void SetWeaponRightSlot(Weapon weapon)
        {
            _weapon = weapon;
        }
    }
}