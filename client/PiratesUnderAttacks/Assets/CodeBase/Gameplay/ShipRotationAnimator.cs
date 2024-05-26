using UnityEngine;

namespace CodeBase.Gameplay
{
    public class ShipRotationAnimator : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private Transform _body;

        private void Update()
        {
            var targetDirection = _ship.RotationDirection;
            var currentDirection = _ship.transform.forward;
            
            Debug.DrawLine(_ship.transform.position, _ship.transform.position + _ship.RotationDirection * 10, Color.green);
            
            var angle = Vector3.SignedAngle(targetDirection, currentDirection, Vector3.up);
            
            if (Mathf.Approximately(angle, 0))
            {
                _body.localEulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                _body.localEulerAngles = new Vector3(0, 0, Mathf.Sign(angle) * -25);
            }
        }
    }
}