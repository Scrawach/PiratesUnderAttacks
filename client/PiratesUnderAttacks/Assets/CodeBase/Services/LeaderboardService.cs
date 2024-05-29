using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBase.Services
{
    public class LeaderboardService
    {
        private readonly SkinStaticData _staticData;
        private readonly Dictionary<string, LeaderInfo> _leaders;

        public LeaderboardService(SkinStaticData staticData)
        {
            _staticData = staticData;
            _leaders = new Dictionary<string, LeaderInfo>();
        }

        public event Action Updated;
        
        public void CreateLeader(string playerId)
        {
            var skin = _staticData.ForShipSkin(0);
            
            _leaders[playerId] = new LeaderInfo()
            {
                Position = _leaders.Count + 1,
                Username = "username",
                Score = 10,
                Color = skin.color,
            };
            Updated?.Invoke();
        }

        public void RemoveLeader(string playerId)
        {
            _leaders.Remove(playerId);
            Updated?.Invoke();
        }

        public void UpdateLeader(string playerId, int score)
        {
            _leaders[playerId].Score = score;
            Updated?.Invoke();
        }

        public IEnumerable<LeaderInfo> GetLeadersSortedByPosition() => 
            SortByPosition(_leaders.Values);

        private IEnumerable<LeaderInfo> SortByPosition(IEnumerable<LeaderInfo> leaders)
        {
            var orderedLeaders = leaders.OrderByDescending(leader => leader.Score);
            var position = 1;
            foreach (var orderedLeader in orderedLeaders)
            {
                orderedLeader.Position = position;
                position++;
                yield return orderedLeader;
            }
        }
    }
}