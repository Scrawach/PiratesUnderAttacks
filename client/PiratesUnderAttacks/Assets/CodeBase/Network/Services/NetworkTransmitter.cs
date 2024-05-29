using System.Collections.Generic;
using CodeBase.Generated;
using CodeBase.Network.Extensions;
using CodeBase.Network.Services.Handlers;
using Colyseus;
using UnityEngine;

namespace CodeBase.Network.Services
{
    public class NetworkTransmitter : INetworkRoomHandler
    {
        private const string MovementEndPoint = "move";
        private const string FireEndPoint = "fire";
        private const string TakeDamageEndPoint = "takeDamage";

        private ColyseusRoom<GameRoomState> _room;

        public void Handle(ColyseusRoom<GameRoomState> room) => 
            _room = room;

        public void Dispose() => 
            _room = null;

        public void SendMovement(Vector3 position, Vector3 rotation, Vector3 input)
        {
            var message = new Dictionary<string, object>()
            {
                [nameof(position)] = position.ToVector2(),
                [nameof(rotation)] = rotation.y,
                [nameof(input)] = input.ToVector2()
            };

            _room.Send(MovementEndPoint, message);
        }

        public void SendFire() => 
            _room.Send(FireEndPoint, _room.SessionId);

        public void SendTakeDamage(string attackerId, int currentHealth) => 
            _room.Send(TakeDamageEndPoint, new Dictionary<string, object>()
            {
                [nameof(attackerId)] = attackerId,
                [nameof(currentHealth)] = currentHealth
            });
    }
}