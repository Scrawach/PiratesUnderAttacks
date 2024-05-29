using CodeBase.Gameplay.Services;
using Reflex.Attributes;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class LocalPlayer : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private ShipArmaments _armaments;

        private Camera _camera;
        private InputService _input;
        
        [Inject]
        public void Construct(InputService input) => 
            _input = input;

        private void Awake() => 
            _camera = Camera.main;

        private void Update()
        {
            var inputRelativeByCamera = _camera.transform.TransformDirection(_input.InputAxis());
            inputRelativeByCamera.y = 0;
            _ship.LookAt(_ship.transform.position + inputRelativeByCamera.normalized);

            if (_input.IsFire())
                _armaments.TryFire();
        }
    }
}