using UnityEngine;

namespace CodeBase.Gameplay
{
    public class LocalPlayer : MonoBehaviour
    {
        [SerializeField] private Ship _ship;

        private Camera _camera;

        private void Awake() => 
            _camera = Camera.main;

        private void Update()
        {
            var inputRelativeByCamera = _camera.transform.TransformDirection(InputAxis().normalized);
            _ship.LookAt(_ship.transform.position + inputRelativeByCamera);
        }

        private static Vector3 InputAxis() =>
            new(
                x: Input.GetAxis("Horizontal"),
                y: 0,
                z: Input.GetAxis("Vertical")
            );
    }
}