using UnityEngine;

namespace CodeBase.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _effectiveDistance;
        [SerializeField] private float _gravityDamp;

        private float _elapsedDistance;

        private Vector3 _startMovement;

        public void Launch(Vector3 startMovement) => 
            _startMovement = startMovement;

        private void Update()
        {
            var moveStep = Time.deltaTime * _speed;
            var movement = _startMovement + transform.forward * moveStep;

            if (_elapsedDistance >= _effectiveDistance)
                movement += (Physics.gravity * Time.deltaTime) / _gravityDamp;
            
            transform.Translate(movement, Space.World);
            _elapsedDistance += moveStep;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health health))
                health.TakeDamage(_damage);
        }
    }
}