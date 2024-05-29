using CodeBase.Generated;
using Colyseus;
using UnityEngine;

namespace CodeBase.Network.Services.Handlers
{
    public class NetworkStateInitializer : INetworkRoomHandler
    {
        private readonly NetworkPlayerInitializer _playerInitializer;

        private ColyseusRoom<GameRoomState> _room;

        public NetworkStateInitializer(NetworkPlayerInitializer playerInitializer) => 
            _playerInitializer = playerInitializer;

        public void Handle(ColyseusRoom<GameRoomState> room)
        {
            _room = room;
            _room.OnStateChange += OnStateChanged;
        }

        private void OnStateChanged(GameRoomState state, bool isFirstTime)
        {
            if (isFirstTime == false)
                return;

            _room.OnStateChange -= OnStateChanged;
            _playerInitializer.Initialize(state);
        }

        public void Dispose()
        {
            _room = null;
            _playerInitializer.Dispose();
        }
    }
}