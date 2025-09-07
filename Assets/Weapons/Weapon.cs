using UnityEngine;
using UnityEngine.UI;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Sprite _sprite;

        public Sprite IConWeapon
        {
            get => _sprite;
            set => _sprite = value;
        }

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
    }
}