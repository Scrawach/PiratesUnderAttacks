using System.Collections.Generic;
using CodeBase.Generated;
using CodeBase.Network.Services.Handlers;
using Colyseus;
using UnityEngine;

namespace CodeBase.Network.Services
{
    public class NetworkTransmitter : INetworkRoomHandler
    {
        private const string MovementEndPoint = "move";

        private ColyseusRoom<GameRoomState> _room;

        public void Handle(ColyseusRoom<GameRoomState> room) => 
            _room = room;

        public void Dispose() => 
            _room = null;

        public void SendMovement(Vector3 position, Vector3 rotation, Vector3 input)
        {
            var message = new Dictionary<string, object>()
            {
                [nameof(position)] = position,
                [nameof(rotation)] = rotation,
                [nameof(input)] = input
            };

            _room.Send(MovementEndPoint, message);
        }
    }
}