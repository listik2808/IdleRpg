using Screpts.Services;
using Scripts.CameraLogic;
using Scripts.Infrastructure;
using UnityEngine;

namespace Screpts.Hero
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private Camera _camera;
        private IInputServices _inputServices;

        private void Awake()
        {
            _inputServices = Game.InputServices;
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;
            if (_inputServices.Axis.sqrMagnitude > 0.001f)
            {
                movementVector = _camera.transform.TransformDirection(_inputServices.Axis);
                movementVector.y = 0;
                movementVector.Normalize();
                transform.forward = movementVector;
            }
            movementVector += Physics.gravity;
            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }
    }
}