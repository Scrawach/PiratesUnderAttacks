using UnityEngine;

namespace CodeBase.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update() => 
            transform.Translate(transform.forward * Time.deltaTime * _speed, Space.World);
    }
}