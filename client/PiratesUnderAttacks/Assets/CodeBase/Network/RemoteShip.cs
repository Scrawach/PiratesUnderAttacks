using System;
using System.Collections.Generic;
using CodeBase.Common.Extensions;
using CodeBase.Gameplay;
using CodeBase.Generated;
using CodeBase.Network.Extensions;
using UnityEngine;

namespace CodeBase.Network
{
    public class RemoteShip : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private Health _health;
        
        private readonly List<Action> _disposes = new();
        private Vector3 _previousInput;
        
        public void Initialize(PlayerSchema schema)
        {
            schema.OnPositionChange(OnPositionChanged).AddTo(_disposes);
            schema.OnRotationChange(OnRotationChanged).AddTo(_disposes);
            schema.OnInputChange(OnInputChanged).AddTo(_disposes);
            schema.OnCurrentHealthChange(OnCurrentHealthChanged).AddTo(_disposes);
            schema.OnTotalHealthChange(OnTotalHealthChanged).AddTo(_disposes);
        }
        
        private void OnCurrentHealthChanged(byte current, byte previous) => 
            _health.SetCurrentHealth(current);

        private void OnTotalHealthChanged(byte current, byte previous) => 
            _health.SetTotalHealth(current);


        private void OnPositionChanged(Vector2Schema current, Vector2Schema previous)
        {
            var distance = Vector3.Distance(current.ToVector3(), _ship.transform.position);

            if (distance > 1f) 
                _ship.transform.position = new Vector3(current.x, 0f, current.y);
        }

        private void OnRotationChanged(float current, float previous)
        {
            //_ship.transform.eulerAngles = new Vector3(0f, current, 0f);
        }

        private void OnInputChanged(Vector2Schema current, Vector2Schema previous) => 
            _previousInput = current.ToVector3().normalized;

        private void Update() => 
            _ship.LookAt(_ship.transform.position + _previousInput);

        private void OnDestroy()
        {
            _disposes.ForEach(dispose => dispose?.Invoke());
            _disposes.Clear();
        }
    }
}