using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class Health : MonoBehaviour
    {
        [field: SerializeField] public int Max { get; private set; }
        [field: SerializeField] public int Current { get; private set; }
        
        public event Action Changed;

        public float Ratio => Current * 1f / Max;
        
        public void TakeDamage(int damage)
        {
            Current = Mathf.Clamp(Current - damage, 0, Max);
            Changed?.Invoke();
        }
    }
}