using System;
using System.Collections.Generic;
using CodeBase.Common.Extensions;
using CodeBase.Gameplay;
using CodeBase.Generated;
using UnityEngine;

namespace CodeBase.Network
{
    public class RemoteShip : MonoBehaviour
    {
        [SerializeField] private UniqueId _uniqueId;
        [SerializeField] private Ship _ship;
        
        private readonly List<Action> _disposes = new();
        
        public void Initialize(PlayerSchema schema) => 
            schema.OnPositionChange(OnPositionChanged).AddTo(_disposes);

        private void OnPositionChanged(Vector2Schema current, Vector2Schema previous) => 
            _ship.transform.position = new Vector3(current.x, 0f, current.y);

        private void OnDestroy()
        {
            _disposes.ForEach(dispose => dispose?.Invoke());
            _disposes.Clear();
        }
    }
}