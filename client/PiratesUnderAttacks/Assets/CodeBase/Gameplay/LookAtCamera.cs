using CodeBase.Gameplay.Services;
using Reflex.Attributes;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class LookAtCamera : MonoBehaviour
    {
        private CameraFollow _camera;

        [Inject]
        public void Construct(CameraFollow cameraFollow) => 
            _camera = cameraFollow;
        
        private void LateUpdate() => 
            transform.LookAt(_camera.VirtualCamera.transform);
    }
}