using UnityEngine;

namespace CodeBase.Gameplay
{
    public class SpawnDeathEffect : MonoBehaviour
    {
        [SerializeField] private ShipDeath _death;
        [SerializeField] private GameObject _vfx;
        
        private void OnEnable() => 
            _death.Happened += OnDeathHappened;

        private void OnDisable() => 
            _death.Happened -= OnDeathHappened;

        private void OnDeathHappened() => 
            Instantiate(_vfx, transform.position, Quaternion.identity);
    }
}