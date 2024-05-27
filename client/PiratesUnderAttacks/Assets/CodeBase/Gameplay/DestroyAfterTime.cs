using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField] private float _timeInSeconds;

        private void Awake() => 
            Destroy(gameObject, _timeInSeconds);
    }
}