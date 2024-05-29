using CodeBase.Gameplay;
using CodeBase.Generated;
using CodeBase.Network.Services.Handlers;
using UnityEngine;

namespace CodeBase.Network.Services.Factory
{
    public class NetworkShipFactory
    {
        private readonly INetworkStatusProvider _status;
        private readonly ShipFactory _shipFactory;

        public NetworkShipFactory(INetworkStatusProvider status, ShipFactory shipFactory)
        {
            _status = status;
            _shipFactory = shipFactory;
        }

        public Ship CreateShip(string id, PlayerSchema schema) => 
            _status.IsLocalPlayer(id) 
                ? _shipFactory.CreatePlayerShip(id, schema) 
                : _shipFactory.CreateRemoteShip(id, schema);

        public bool RemoveShip(string id) => 
            _shipFactory.RemoveShip(id);
    }
}