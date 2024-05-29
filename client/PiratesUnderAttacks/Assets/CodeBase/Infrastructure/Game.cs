using CodeBase.Network.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        private readonly NetworkClient _client;

        public Game(NetworkClient client) => 
            _client = client;

        public void Start()
        {
            Debug.Log($"Game started!");
        }

        public async UniTask<ConnectionResult> Connect(string username) => 
            await _client.Connect(username);

        public async UniTask Disconnect() => 
            await _client.Disconnect();
    }
}