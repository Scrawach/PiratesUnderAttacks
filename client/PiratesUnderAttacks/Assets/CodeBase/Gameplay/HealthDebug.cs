using UnityEngine;

namespace CodeBase.Gameplay
{
    public class HealthDebug : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private void OnEnable() => 
            _health.Changed += OnHealthChanged;

        private void OnDisable() => 
            _health.Changed -= OnHealthChanged;

        private void OnHealthChanged()
        {
            Debug.Log($"{_health.Current} / {_health.Max} ({_health.Ratio})");
        }
    }
}