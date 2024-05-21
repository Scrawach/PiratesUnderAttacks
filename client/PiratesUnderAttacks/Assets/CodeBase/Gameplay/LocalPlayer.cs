using UnityEngine;

namespace CodeBase.Gameplay
{
    public class LocalPlayer : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private ShipArmaments _armaments;

        private Camera _camera;

        private void Awake() => 
            _camera = Camera.main;

        private void Update()
        {
            var inputRelativeByCamera = _camera.transform.TransformDirection(InputAxis());
            inputRelativeByCamera.y = 0;
            _ship.LookAt(_ship.transform.position + inputRelativeByCamera.normalized);

            if (Input.GetKeyDown(KeyCode.Space))
                _armaments.TryFire();
        }

        private static Vector3 InputAxis() =>
            new(
                x: Input.GetAxis("Horizontal"),
                y: 0,
                z: Input.GetAxis("Vertical")
            );
    }
}