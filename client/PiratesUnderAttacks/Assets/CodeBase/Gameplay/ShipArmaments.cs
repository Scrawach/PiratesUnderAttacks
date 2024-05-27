using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class ShipArmaments : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private List<ShipCannon> _cannons;
        [SerializeField] private Bullet _projectilePrefab;
        [SerializeField] private float _fireDelay = 1f;

        private Coroutine _firing;
        
        public bool TryFire()
        {
            if (_firing != null)
                return false;
            
            _firing = StartCoroutine(Firing(_fireDelay));
            
            return true;
        }

        private IEnumerator Firing(float delay)
        {
            foreach (var cannon in _cannons) 
                cannon.PlayFire();

            yield return new WaitForSeconds(delay);

            foreach (var cannon in _cannons) 
                CreateProjectile(cannon.FirePoint);

            _firing = null;
        }

        private Bullet CreateProjectile(Transform point)
        {
            var bullet = Instantiate(_projectilePrefab, point.position, point.rotation);
            bullet.Launch(_ship.Movement);
            return bullet;
        }
    }
}