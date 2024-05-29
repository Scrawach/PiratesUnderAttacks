using Cinemachine;
using CodeBase.Gameplay.Services;
using CodeBase.Water;
using Reflex.Attributes;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private WaterInteraction _waterInteraction;
        
        private Game _game;
        private CameraFollow _camera;

        [Inject]
        public void Construct(Game game, CameraFollow cameraFollow)
        {
            _game = game;
            _camera = cameraFollow;
        }

        private void Start()
        {
            _game.Start();
            _camera.SetMainVirtualCamera(_virtualCamera);
            _camera.SetWaterInteraction(_waterInteraction);
        }

        private async void OnDestroy() => 
            await _game.Disconnect();
    }
}