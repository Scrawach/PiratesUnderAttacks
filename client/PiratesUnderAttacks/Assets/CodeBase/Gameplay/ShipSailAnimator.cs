using UnityEngine;

namespace CodeBase.Gameplay
{
    public class ShipSailAnimator : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        [SerializeField] private Ship _ship;
        [SerializeField] private Animator _animator;

        private void Update() => 
            _animator.SetBool(IsMoving, _ship.IsMoving);
    }
}