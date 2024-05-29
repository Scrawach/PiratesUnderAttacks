using CodeBase.Gameplay.Services;
using CodeBase.Network.Services;
using Reflex.Attributes;
using UnityEngine;

namespace CodeBase.Network
{
    public class PlayerNetworkSync : MonoBehaviour
    {
        private NetworkTransmitter _transmitter;
        private InputService _input;

        [Inject]
        public void Construct(NetworkTransmitter transmitter, InputService input)
        {
            _transmitter = transmitter;
            _input = input;
        }

        private void Update() => 
            _transmitter.SendMovement(transform.position, transform.rotation.eulerAngles, _input.InputAxis());
    }
}