using UnityEngine;

namespace CodeBase.Gameplay
{
    public class ShipArmaments : MonoBehaviour
    {
        public bool TryFire()
        {
            Debug.Log($"FIRED!");
            return true;
        }
    }
}