using Cinemachine;
using CodeBase.Gameplay.Services;
using Reflex.Attributes;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        
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
        }

        private async void OnDestroy() => 
            await _game.Disconnect();
    }
}