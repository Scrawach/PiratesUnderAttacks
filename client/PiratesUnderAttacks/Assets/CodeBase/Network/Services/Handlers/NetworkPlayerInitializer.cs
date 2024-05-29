using System;
using System.Collections.Generic;
using CodeBase.Common.Extensions;
using CodeBase.Generated;
using CodeBase.Network.Services.Factory;
using UnityEngine;

namespace CodeBase.Network.Services.Handlers
{
    public class NetworkPlayerInitializer : IDisposable
    {
        private readonly NetworkShipFactory _networkShipFactory;
        private readonly List<Action> _disposes;

        public NetworkPlayerInitializer(NetworkShipFactory networkShipFactory)
        {
            _networkShipFactory = networkShipFactory;
            _disposes = new List<Action>();
        }

        public void Initialize(GameRoomState state)
        {
            state.players.OnAdd(OnPlayerAdded).AddTo(_disposes);
            state.players.OnRemove(OnPlayerRemoved).AddTo(_disposes);
        }
        
        public void Dispose()
        {
            _disposes.ForEach(dispose => dispose?.Invoke());
            _disposes.Clear();
        }
        
        private void OnPlayerAdded(string key, PlayerSchema schema) => 
            _networkShipFactory.CreateShip(key, schema);

        private void OnPlayerRemoved(string key, PlayerSchema schema) => 
            _networkShipFactory.RemoveShip(key);
    }
}