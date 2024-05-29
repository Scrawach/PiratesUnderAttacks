using Cinemachine;
using CodeBase.Water;
using UnityEngine;

namespace CodeBase.Gameplay.Services
{
    public class CameraFollow
    {
        private CinemachineVirtualCamera _main;
        private WaterInteraction _waterInteraction;
        
        public CinemachineVirtualCamera VirtualCamera => _main;

        public void SetMainVirtualCamera(CinemachineVirtualCamera main) => 
            _main = main;

        public void Follow(Transform target)
        {
            _main.Follow = target;
            _main.LookAt = target;
            _waterInteraction.AddInteractor(target);
        }
        
        public void SetWaterInteraction(WaterInteraction waterInteraction) => 
            _waterInteraction = waterInteraction;
    }
}