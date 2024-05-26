using UnityEngine;

namespace CodeBase.Gameplay
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        
        private Quaternion _targetRotation;
        
        public Vector3 RotationDirection { get; private set; }

        public void LookAt(Vector3 target)
        {
            var direction = target - transform.position;

            if (direction != Vector3.zero) 
                _targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        
        private void Update()
        {
            ProcessMovement();
            ProcessRotation();
        }

        private void ProcessMovement()
        {
            var timeStep = Time.deltaTime * _speed;
            transform.Translate(transform.forward * timeStep, Space.World);
        }

        private void ProcessRotation()
        {
            RotationDirection = transform.forward;
            var timeStep = Time.deltaTime * _rotationSpeed;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, timeStep);
            _targetRotation = transform.rotation;
        }
    }
}