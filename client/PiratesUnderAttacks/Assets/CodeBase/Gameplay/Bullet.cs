using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _effectiveDistance;
        [SerializeField] private ParticleSystem _vfx;
        [SerializeField] private ParticleSystem _aura;
        
        private float _elapsedDistance;

        private string _ownerId;
        private Vector3 _startMovement;

        public void Launch(string ownerId, Vector3 startMovement, Color color)
        {
            _ownerId = ownerId;
            _startMovement = startMovement;
            
            _aura.Stop();
            var main = _aura.main;
            main.startColor = color;
            _aura.Play();
        }

        private void Update()
        {
            var moveStep = Time.deltaTime * _speed;
            var movement = _startMovement + transform.forward * moveStep;

            if (_elapsedDistance >= _effectiveDistance) 
                ProcessBulletDeath();

            transform.Translate(movement, Space.World);
            _elapsedDistance += moveStep;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health health))
            {
                health.TakeDamage(_damage, _ownerId);
                ProcessBulletDeath();
            }
        }

        private void ProcessBulletDeath()
        {
            Instantiate(_vfx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}