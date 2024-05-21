using UnityEngine;

namespace CodeBase.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _effectiveDistance;
        [SerializeField] private float _gravityDamp;

        private float _elapsedDistance;
        
        private void Update()
        {
            var moveStep = Time.deltaTime * _speed;
            var movement = transform.forward * moveStep;

            if (_elapsedDistance >= _effectiveDistance)
                movement += (Physics.gravity * Time.deltaTime) / _gravityDamp;
            
            transform.Translate(movement, Space.World);
            _elapsedDistance += moveStep;
        }
    }
}