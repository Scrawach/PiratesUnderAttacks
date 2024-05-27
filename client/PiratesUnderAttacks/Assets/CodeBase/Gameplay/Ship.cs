using System;
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

        public void LookAt(Vector3 target)
        {
            var direction = target - transform.position;

            if (direction != Vector3.zero)
            {
                IsMoving = true;
                _targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            }
            else
            {
                IsMoving = false;
            }
        }
        
        private void Update()
        {
            if (IsMoving)
                ProcessMovement();
            
            ProcessRotation();
        }

        private void ProcessMovement()
        {
            var timeStep = Time.deltaTime * _speed;
            Movement = transform.forward * timeStep;
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