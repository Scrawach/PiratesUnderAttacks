using UnityEngine;

namespace CodeBase.Gameplay
{
    public class DestroyAfterDeath : MonoBehaviour
    {
        [SerializeField] private ShipDeath _death;

        private void OnEnable() => 
            _death.Happened += OnDeathHappened;

        private void OnDisable() => 
            _death.Happened -= OnDeathHappened;

        private void OnDeathHappened()
        {
            Destroy(gameObject);
        }
    }
}