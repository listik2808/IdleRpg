using Screpts.Services;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameJoystick : MonoBehaviour
    {
        [SerializeField] private GameObject _joystick;

        private void Start()
        {
            TryJoystickDiactivate();
        }

        private void TryJoystickDiactivate()
        {
            if (Game.IsMobile == false)
                _joystick.gameObject.SetActive(false);
        }
    }
}