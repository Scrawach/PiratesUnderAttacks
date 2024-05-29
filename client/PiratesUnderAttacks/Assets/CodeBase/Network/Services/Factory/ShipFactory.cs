using CodeBase.Gameplay;
using CodeBase.Generated;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Installers;
using CodeBase.Network.Extensions;
using CodeBase.Network.Services.Ships;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Network.Services.Factory
{
    public class ShipFactory
    {
        private const string PlayerShipPath = "Ships/Player Ship";
        private const string RemoteShipPath = "Ships/Remote Ship";
        
        private readonly Assets _assets;
        private readonly Injector _injector;
        private readonly ShipRegistry _registry;
        private readonly SkinStaticData _skinStaticData;

        public ShipFactory(Assets assets, Injector injector, ShipRegistry registry, SkinStaticData skinStaticData)
        {
            _assets = assets;
            _injector = injector;
            _registry = registry;
            _skinStaticData = skinStaticData;
        }

        public Ship CreatePlayerShip(string id, PlayerSchema schema)
        {
            Debug.Log($"Create player {id}");
            return CreateShip(id, schema, PlayerShipPath);
        }

        public Ship CreateRemoteShip(string id, PlayerSchema schema)
        {
            Debug.Log($"Create remote {id}");
            var ship = CreateShip(id, schema, RemoteShipPath);
            ship.GetComponent<RemoteShip>().Initialize(schema);
            return ship;
        }

        public Ship CreateShip(string id, PlayerSchema schema, string pathToPrefab)
        {
            var prefab = _assets.Load<GameObject>(pathToPrefab);
            var skinMaterial = _skinStaticData.ForShipSkin(schema.skinId);
            var ship = Object.Instantiate(prefab, schema.position.ToVector3(), Quaternion.identity);
            
            _injector.Inject(ship);
            
            _registry.Add(new ShipInfo(id, ship, schema));
            
            ship.GetComponent<UniqueId>().Construct(id);
            ship.GetComponent<SkinRenderer>().ChangeTo(skinMaterial);
            
            return ship.GetComponent<Ship>();
        }

        public bool RemoveShip(string id)
        {
            var ship = _registry[id];
            _registry.Remove(id);
            Object.Destroy(ship.Instance.gameObject);
            return true;
        }
    }
}