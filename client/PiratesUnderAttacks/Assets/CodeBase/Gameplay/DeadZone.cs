using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] private float _tickDuration = 1f;
        [SerializeField] private int _damageForTick = 10;
        
        private readonly List<Health> _targets = new();

        private float _elapsedTime;
        
        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime < _tickDuration) 
                return;
            
            _elapsedTime -= _tickDuration;

            foreach (var target in _targets) 
                target.TakeDamage(_damageForTick);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Health health))
                _targets.Add(health);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health health))
                _targets.Remove(health);
        }
    }
}