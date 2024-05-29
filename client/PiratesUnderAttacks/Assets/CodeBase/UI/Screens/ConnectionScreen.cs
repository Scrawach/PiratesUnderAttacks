using System;
using CodeBase.Infrastructure;
using CodeBase.UI.Screens.Controls;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using UnityEngine;

namespace CodeBase.UI.Screens
{
    public class ConnectionScreen : GameScreen
    {
        private const string EmptyUsernameMessage = "EMPTY USERNAME!";
        private const string QuitMessage = "QUIT FROM WHERE?";

        private Game _game;
        private ConnectionPanel _panel;

        [Inject]
        public void Construct(Game game) => 
            _game = game;

        public event Action Connected;

        protected override void Awake()
        {
            base.Awake();
            _panel = new ConnectionPanel(Screen);
        }

        private void OnEnable()
        {
            _panel.ConnectClicked += OnConnectClicked;
            _panel.QuitClicked += OnQuitClicked;
        }
        
        private void OnDisable()
        {
            _panel.ConnectClicked -= OnConnectClicked;
            _panel.QuitClicked -= OnQuitClicked;
        }
        
        private void OnConnectClicked() => 
            ConnectToServer().Forget();

        private void OnQuitClicked() => 
            _panel.ShowError(QuitMessage);

        private async UniTask ConnectToServer()
        {
            _panel.HideError();

            if (string.IsNullOrWhiteSpace(_panel.Username))
            {
                _panel.ShowError(EmptyUsernameMessage);
                return;
            }
            
            _panel.BlockButtons();
            var result = await _game.Connect(_panel.Username);
            
            if (result.IsSuccess)
                Connected?.Invoke();
            else
                _panel.ShowError(result.Message);
            
            _panel.UnblockButtons();
        }
    }
}