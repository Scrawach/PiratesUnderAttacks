using System;
using CodeBase.Generated;
using Colyseus;

namespace CodeBase.Network.Services.Handlers
{
    public interface INetworkRoomHandler : IDisposable
    {
        void Handle(ColyseusRoom<GameRoomState> room);
    }
}