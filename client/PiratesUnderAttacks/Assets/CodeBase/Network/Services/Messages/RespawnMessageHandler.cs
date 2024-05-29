using CodeBase.Gameplay;
using CodeBase.Generated;
using CodeBase.Network.Extensions;
using CodeBase.Network.Services.Handlers;
using CodeBase.Network.Services.Ships;
using Colyseus;

namespace CodeBase.Network.Services.Messages
{
    public class RespawnMessageHandler : INetworkRoomHandler
    {
        private const string FireMessageName = "respawn";

        private readonly ShipRegistry _registry;
        private readonly INetworkStatusProvider _statusProvider;

        public RespawnMessageHandler(ShipRegistry registry, INetworkStatusProvider networkStatus)
        {
            _registry = registry;
            _statusProvider = networkStatus;
        }

        public void Handle(ColyseusRoom<GameRoomState> room) => 
            room.OnMessage<Vector2Schema>(FireMessageName, OnMessageReceived);

        private void OnMessageReceived(Vector2Schema respawnPosition)
        {
            var ship = _registry[_statusProvider.PlayerId];

            ship.Instance.GetComponent<Health>().Restore();
            ship.Instance.transform.position = respawnPosition.ToVector3();
        }

        public void Dispose()
        {
            
        }
    }
}