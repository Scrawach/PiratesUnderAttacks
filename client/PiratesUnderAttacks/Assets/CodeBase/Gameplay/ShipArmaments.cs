using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class ShipArmaments : MonoBehaviour
    {
        [SerializeField] private List<Transform> _shootPoints;
        [SerializeField] private GameObject _projectilePrefab;

        public bool TryFire()
        {
            foreach (var shootPoint in _shootPoints) 
                CreateProjectile(shootPoint);
            
            return true;
        }

        private GameObject CreateProjectile(Transform point) => 
            Instantiate(_projectilePrefab, point.position, point.rotation);
    }
}