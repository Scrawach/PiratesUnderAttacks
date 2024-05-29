using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class Health : MonoBehaviour
    {
        [field: SerializeField] public int Max { get; private set; }
        [field: SerializeField] public int Current { get; private set; }
        
        public event Action Changed;
        public event Action<string> ChangedByAttacker; 

        public float Ratio => Current * 1f / Max;
        
        public void TakeDamage(int damage)
        {
            Current = Mathf.Clamp(Current - damage, 0, Max);
            Changed?.Invoke();
        }
        
        public void TakeDamage(int damage, string attackedId)
        {
            TakeDamage(damage);
            ChangedByAttacker?.Invoke(attackedId);
        }

        public void SetTotalHealth(byte current)
        {
            Max = current;
            TakeDamage(0);
        }

        public void SetCurrentHealth(byte current)
        {
            Current = current;
            TakeDamage(0);
        }

        public void Restore()
        {
            Current = Max;
            TakeDamage(0);
        }
    }
}