using CodeBase.Generated;

namespace CodeBase.Network.Services.Ships
{
    public class ShipInfo
    {
        public string Id;
        public RemoteShip Ship;
        public PlayerSchema Player;

        public ShipInfo(string id, RemoteShip ship, PlayerSchema player)
        {
            Id = id;
            Ship = ship;
            Player = player;
        }
    }
}