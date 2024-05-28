using System;
using System.Collections.Generic;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] private float _tickDuration = 1f;
        [SerializeField] private int _damageForTick = 10;
        [SerializeField] private UIRoot _root;
        
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
            _root.ShowDeadZoneWarning();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health health))
                _targets.Remove(health);
            _root.HideDeadZoneWarning();
        }
    }
}