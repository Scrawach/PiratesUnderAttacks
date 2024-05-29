using CodeBase.Generated;
using UnityEngine;

namespace CodeBase.Network.Services.Ships
{
    public class ShipInfo
    {
        public string Id;
        public GameObject Instance;
        public PlayerSchema Player;

        public ShipInfo(string id, GameObject instance, PlayerSchema player)
        {
            Id = id;
            Instance = instance;
            Player = player;
        }
    }
}