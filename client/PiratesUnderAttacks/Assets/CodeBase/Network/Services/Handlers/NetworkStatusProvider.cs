using CodeBase.Generated;
using Colyseus;

namespace CodeBase.Network.Services.Handlers
{
    public class NetworkStatusProvider : INetworkRoomHandler, INetworkStatusProvider
    {
        private ColyseusRoom<GameRoomState> _room;
        
        public void Handle(ColyseusRoom<GameRoomState> room) => 
            _room = room;

        public void Dispose() => 
            _room = null;

        public bool IsLocalPlayer(string id) => 
            _room.SessionId == id;
    }
}