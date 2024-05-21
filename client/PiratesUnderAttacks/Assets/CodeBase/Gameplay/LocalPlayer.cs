using UnityEngine;

namespace CodeBase.Gameplay
{
    public class LocalPlayer : MonoBehaviour
    {
        [SerializeField] private Ship _ship;

        private void Update()
        {
            _ship.LookAt(_ship.transform.position + InputAxis());
        }

        private static Vector3 InputAxis() =>
            new(
                x: Input.GetAxis("Horizontal"),
                y: 0,
                z: Input.GetAxis("Vertical")
            );
    }
}