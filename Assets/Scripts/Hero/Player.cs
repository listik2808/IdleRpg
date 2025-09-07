using System;
using UnityEngine;
using Weapons;

namespace Screpts.Hero
{
    public class Player : MonoBehaviour 
    {
        [SerializeField] private HeroHealth _heroHealth;
        [SerializeField] private HeroArmor _heroArmor;
        [SerializeField] private Attack _attack;
        private FastSlot _fastSlot;
        private RightHandSlot _rightHandSlot;

        private void OnDestroy()
        {
            _fastSlot.Click -= WeaponReplacement;
        }

        public void SetSlots(FastSlot fastSlot, RightHandSlot rightHandSlot)
        {
            _fastSlot = fastSlot;
            _rightHandSlot = rightHandSlot;
            _fastSlot.Click += WeaponReplacement;
        }

        public void TakeDamage(float damage)
        {
            if(damage > _heroArmor.Armor)
            {
                damage -= _heroArmor.Armor;
                _heroHealth.TakeDamage(damage);
            }
            else
            {
                _heroHealth.TakeDamage(0);
            }
        }

        private void WeaponReplacement(Weapon weapon)
        {
            Weapon currentweapon = _rightHandSlot.Weapon;
            Weapon slotWeapon = weapon;
            _rightHandSlot.SetWeaponRightSlot(slotWeapon);
            _fastSlot.SetWeapon(currentweapon);
            _fastSlot.Weapon.gameObject.SetActive(false);
            _rightHandSlot.Weapon.gameObject.SetActive(true);
        }
    }
}