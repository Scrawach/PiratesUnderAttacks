using UnityEngine;

namespace CodeBase.Gameplay
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _camera;

        private void Awake() => 
            _camera = Camera.main;

        private void LateUpdate() => 
            transform.LookAt(_camera.transform);
    }
}