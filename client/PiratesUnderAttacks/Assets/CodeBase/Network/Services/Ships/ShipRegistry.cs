using System;
using System.Collections.Generic;
using Action = System.Action;

namespace CodeBase.Network.Services.Ships
{
    public class ShipRegistry
    {
        private readonly Dictionary<string, ShipInfo> _ships;

        public ShipRegistry() => 
            _ships = new Dictionary<string, ShipInfo>();

        public event Action Updated;
        public event Action<ShipInfo> Added;
        public event Action<ShipInfo> Removed;

        public IEnumerable<ShipInfo> All() =>
            _ships.Values;

        public bool Contains(string id) => 
            _ships.ContainsKey(id);

        public void Add(ShipInfo info)
        {
            _ships[info.Id] = info;
            Updated?.Invoke();
            Added?.Invoke(info);
        }

        public bool Remove(string id)
        {
            if (!_ships.TryGetValue(id, out var info)) 
                return false;
            
            _ships.Remove(id);
            Updated?.Invoke();
            Removed?.Invoke(info);
            return true;
        }

    }
}