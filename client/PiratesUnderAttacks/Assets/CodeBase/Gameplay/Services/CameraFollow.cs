using Cinemachine;
using UnityEngine;

namespace CodeBase.Gameplay.Services
{
    public class CameraFollow
    {
        private CinemachineVirtualCamera _main;

        public void SetMainVirtualCamera(CinemachineVirtualCamera main) => 
            _main = main;

        public void Follow(Transform target)
        {
            _main.Follow = target;
            _main.LookAt = target;
        }
    }
}