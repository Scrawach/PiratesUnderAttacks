using System;
using System.Collections.Generic;
using CodeBase.Common.Extensions;
using CodeBase.Generated;
using CodeBase.Services;
using Reflex.Attributes;
using UnityEngine;

namespace CodeBase.Network
{
    public class NetworkLeader : MonoBehaviour
    {
        [SerializeField] private UniqueId _uniqueId;
        
        private readonly List<Action> _disposes = new();

        private LeaderboardService _leaderboard;

        [Inject]
        public void Construct(LeaderboardService leaderboard) => 
            _leaderboard = leaderboard;

        public void Initialize(PlayerSchema schema)
        {
            _leaderboard.CreateLeader(_uniqueId.Value, schema);
            schema.OnScoreChange(OnScoreChanged).AddTo(_disposes);
        }

        private void OnScoreChanged(ushort current, ushort previous) => 
            _leaderboard.UpdateLeader(_uniqueId.Value, current);

        private void OnDestroy() => 
            _leaderboard.RemoveLeader(_uniqueId.Value);
    }
}