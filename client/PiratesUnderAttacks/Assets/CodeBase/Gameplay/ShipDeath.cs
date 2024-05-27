using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class ShipDeath : MonoBehaviour
    {
        [SerializeField] private Health _health;

        public event Action Happened;
        
        private void OnEnable() => 
            _health.Changed += OnHealthChanged;

        private void OnDisable() => 
            _health.Changed -= OnHealthChanged;

        private void OnHealthChanged()
        {
            if (_health.Current <= 0)
                Happened?.Invoke();
        }
    }
}