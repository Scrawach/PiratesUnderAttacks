using UnityEngine;

namespace CodeBase.Gameplay
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        
        private Quaternion _targetRotation;
        
        public Vector3 RotationDirection { get; private set; }
        
        public Vector3 Movement { get; private set; }
        
        public bool IsMoving { get; private set; }

        private float _strength;
        private float _currentStrength;

        public void LookAt(Vector3 target)
        {
            var direction = target - transform.position;
            
            if (direction != Vector3.zero)
            {
                IsMoving = true;
                _targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                _strength = 1;
            }
            else
            {
                IsMoving = false;
                _strength = 0;
            }
        }
        
        private void Update()
        {
            ProcessMovement();
            
            ProcessRotation();
        }

        private void ProcessMovement()
        {
            var timeStep = Time.deltaTime * _speed;
            _currentStrength += (_strength - _currentStrength) * Time.deltaTime;
            
            Movement = transform.forward * timeStep * _currentStrength;
            transform.Translate(Movement, Space.World);
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