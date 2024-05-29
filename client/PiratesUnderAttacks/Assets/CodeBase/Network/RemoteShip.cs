using System;
using System.Collections.Generic;
using CodeBase.Common.Extensions;
using CodeBase.Gameplay;
using CodeBase.Generated;
using CodeBase.Services;
using Reflex.Attributes;
using UnityEngine;

namespace CodeBase.Network
{
    public class RemoteShip : MonoBehaviour
    {
        [SerializeField] private UniqueId _uniqueId;
        [SerializeField] private Ship _ship;
        
        private readonly List<Action> _disposes = new List<Action>();

        private LeaderboardService _leaderboard;

        [Inject]
        public void Construct(LeaderboardService leaderboard) => 
            _leaderboard = leaderboard;

        public void Initialize(PlayerSchema schema)
        {
            _leaderboard.CreateLeader(_uniqueId.Value, schema);
            schema.OnScoreChange(OnScoreChanged).AddTo(_disposes);
            schema.OnPositionChange(OnPositionChanged).AddTo(_disposes);
        }

        private void OnPositionChanged(Vector2Schema current, Vector2Schema previous) => 
            _ship.transform.position = new Vector3(current.x, 0f, current.y);

        private void OnScoreChanged(ushort current, ushort previous) => 
            _leaderboard.UpdateLeader(_uniqueId.Value, current);

        private void OnDestroy()
        {
            _leaderboard.RemoveLeader(_uniqueId.Value);
            _disposes.ForEach(dispose => dispose?.Invoke());
            _disposes.Clear();
        }
    }
}