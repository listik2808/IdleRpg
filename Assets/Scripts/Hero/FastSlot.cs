using System;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace Screpts.Hero
{
    public class FastSlot : MonoBehaviour
    {
        [SerializeField] private Button _buttonFastSlot;
        [SerializeField] private Image _imageFastSlot;
        [SerializeField] private Weapon _weapon;

        public Weapon Weapon => _weapon;

        public event Action <Weapon>Click;

        private void OnEnable()
        {
            _buttonFastSlot.onClick.AddListener(SetWeapon);
        }

        private void OnDisable()
        {
            _buttonFastSlot.onClick.RemoveListener(SetWeapon);
        }

        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
            _imageFastSlot.sprite = _weapon.IConWeapon;
        }

        private void SetWeapon()
        {
            Click?.Invoke(_weapon);
        }
    }
}