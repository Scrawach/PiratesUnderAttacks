using UnityEngine;

namespace CodeBase.Gameplay
{
    public class LocalPlayer : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;

        private void Update()
        {
            _movement.Move(InputAxis());
        }

        private Vector3 InputAxis() =>
            new(
                x: Input.GetAxis("Horizontal"),
                y: 0,
                z: Input.GetAxis("Vertical")
            );
    }
}