using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed;

        private Vector3 _desiredDirection;
        
        public void Move(Vector3 direction) => 
            _desiredDirection = direction.normalized;

        private void Update()
        {
            var step = Time.deltaTime * _speed;
            var movement = _desiredDirection * step;
            _controller.Move(movement);
        }
    }
}