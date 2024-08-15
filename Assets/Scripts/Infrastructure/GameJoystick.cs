using Screpts.Services;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameJoystick : MonoBehaviour
    {
        [SerializeField] private GameObject _joystick;
        public static IInputServices InputServices;
        private bool _isMobile = false;

        private void Awake()
        {
            RegisterInputService();
            TryJoystickDiactivate();
        }

        private void RegisterInputService()
        {
            if (Application.isEditor)
            {
                InputServices = new StandaloneInputService();
                _isMobile = false;

            }
            else
            {
                InputServices = new MobileInputService();
                _isMobile = true;
            }
        }

        private void TryJoystickDiactivate()
        {
            if (_isMobile == false)
                _joystick.gameObject.SetActive(false);
        }
    }
}