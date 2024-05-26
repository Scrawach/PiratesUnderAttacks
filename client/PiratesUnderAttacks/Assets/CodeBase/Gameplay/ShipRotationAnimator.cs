using System.Collections;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class ShipRotationAnimator : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private Transform _body;

        private float _previousRightRotation;
        
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
                _previousRightRotation = Mathf.Sign(angle);
                var targetAngle = 25 * _previousRightRotation;
                StartCoroutine(Rotating(targetAngle));
            }
        }

        private IEnumerator Rotating(float targetAngle)
        {
            var startAngle = transform.eulerAngles.z;
            var t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime;
                var angle = Mathf.Lerp(startAngle, targetAngle, t);
                _body.localEulerAngles = new Vector3(0, 0, angle);
                yield return null;
            }
        }
    }
}