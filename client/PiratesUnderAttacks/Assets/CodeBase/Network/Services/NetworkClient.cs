using System;
using CodeBase.Generated;
using Colyseus;
using Cysharp.Threading.Tasks;

namespace CodeBase.Network.Services
{
    public class NetworkClient
    {
        private const string GameRoomName = "GameRoom";

        private readonly NetworkStaticData _staticData;
        
        private ColyseusRoom<GameRoomState> _room;

        public NetworkClient(NetworkStaticData staticData) => 
            _staticData = staticData;

        public async UniTask<ConnectionResult> Connect(string username) => 
            await TryConnect(username);

        public async UniTask Disconnect() => 
            await _room.Leave();

        private async UniTask<ConnectionResult> TryConnect(string username)
        {
            var settings = _staticData.ForConnection();
            var client = new ColyseusClient(settings);

            try
            {
                _room = await client.JoinOrCreate<GameRoomState>(GameRoomName);
            }
            catch (Exception exception)
            {
                return ConnectionResult.Failure(exception.Message);
            }

            return ConnectionResult.Success();
        }
    }
}