using UnityEngine;

namespace CodeBase.Gameplay
{
    public class ShipCannon : MonoBehaviour
    {
        private static readonly int Fire = Animator.StringToHash("Fire");

        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _shootPoint;

        public Transform FirePoint => _shootPoint;

        public void PlayFire() => 
            _animator.SetTrigger(Fire);
    }
}