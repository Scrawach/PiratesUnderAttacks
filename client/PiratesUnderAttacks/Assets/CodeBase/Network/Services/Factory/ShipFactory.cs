using CodeBase.Gameplay;
using CodeBase.Generated;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Network.Services.Ships;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Network.Services.Factory
{
    public class ShipFactory
    {
        private const string PlayerShipPath = "";
        private const string RemoteShipPath = "";
        
        private readonly Assets _assets;
        private readonly ShipRegistry _registry;
        private readonly SkinStaticData _skinStaticData;

        public ShipFactory(Assets assets, ShipRegistry registry, SkinStaticData skinStaticData)
        {
            _assets = assets;
            _registry = registry;
            _skinStaticData = skinStaticData;
        }

        public Ship CreatePlayerShip(string id, PlayerSchema schema)
        {
            Debug.Log($"Create player {id}");
            return CreateShip(id, schema);
        }

        public Ship CreateRemoteShip(string id, PlayerSchema schema)
        {
            Debug.Log($"Create remote {id}");
            return CreateShip(id, schema);
        }

        public Ship CreateShip(string id, PlayerSchema schema)
        {
            return null;
        }

        public bool RemoveShip(string id)
        {
            Debug.Log($"remove ship {id}");
            return true;
        }
    }
}