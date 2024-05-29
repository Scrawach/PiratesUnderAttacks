using CodeBase.Gameplay;
using CodeBase.Generated;
using CodeBase.Network.Services.Handlers;
using CodeBase.Network.Services.Ships;
using Colyseus;

namespace CodeBase.Network.Services.Messages
{
    public class FireMessageHandler : INetworkRoomHandler
    {
        private const string FireMessageName = "fire";

        private readonly ShipRegistry _registry;
        private readonly INetworkStatusProvider _statusProvider;

        public FireMessageHandler(ShipRegistry registry, INetworkStatusProvider statusProvider)
        {
            _registry = registry;
            _statusProvider = statusProvider;
        }

        public void Handle(ColyseusRoom<GameRoomState> room) => 
            room.OnMessage<string>(FireMessageName, OnMessageReceived);

        private void OnMessageReceived(string shipId)
        {
            if (_statusProvider.IsLocalPlayer(shipId))
                return;
            
            var ship = _registry[shipId];
            ship.Instance.GetComponent<ShipArmaments>().TryFire();
        }

        public void Dispose()
        {
            
        }
    }
}