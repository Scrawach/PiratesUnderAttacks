using System;
using CodeBase.Gameplay;
using CodeBase.Gameplay.Services;
using CodeBase.Network.Services;
using Reflex.Attributes;
using UnityEngine;

namespace CodeBase.Network
{
    public class PlayerNetworkSync : MonoBehaviour
    {
        [SerializeField] private ShipArmaments _armaments;
        [SerializeField] private Health _health;
        
        private NetworkTransmitter _transmitter;
        private InputService _input;

        [Inject]
        public void Construct(NetworkTransmitter transmitter, InputService input)
        {
            _transmitter = transmitter;
            _input = input;
        }

        private void OnEnable()
        {
            _armaments.Fired += OnArmamentsFired;
            _health.ChangedByAttacker += OnHealthChanged;
        }
        
        private void OnDisable()
        {
            _armaments.Fired -= OnArmamentsFired;
            _health.ChangedByAttacker -= OnHealthChanged;
        }

        private void OnArmamentsFired() => 
            _transmitter.SendFire();
        
        private void OnHealthChanged(string attackerId) => 
            _transmitter.SendTakeDamage(attackerId, _health.Current);

        private void Update() => 
            _transmitter.SendMovement(transform.position, transform.rotation.eulerAngles, _input.InputAxis());
    }
}