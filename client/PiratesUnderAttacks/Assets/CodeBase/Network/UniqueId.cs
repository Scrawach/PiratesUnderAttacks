using UnityEngine;

namespace CodeBase.Network
{
    public class UniqueId : MonoBehaviour
    {
        public void Construct(string id) => 
            Value = id;

        public string Value { get; private set; }
    }
}