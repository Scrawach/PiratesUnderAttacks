using System;
using CodeBase.UI.Screens;
using UnityEngine;

namespace CodeBase.UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private ConnectionScreen _connectionScreen;
        [SerializeField] private LeaderboardScreen _leaderboardScreen;

        [SerializeField] private GameObject _deadZoneWarningUI;

        private void Start()
        {
            _connectionScreen.Show();
            _leaderboardScreen.Hide();
        }

        private void OnEnable() => 
            _connectionScreen.Connected += OnConnected;

        private void OnDisable() => 
            _connectionScreen.Connected -= OnConnected;

        private void OnConnected()
        {
            _connectionScreen.Hide();
            _leaderboardScreen.Show();
        }

        public void ShowDeadZoneWarning() => 
            _deadZoneWarningUI.SetActive(true);

        public void HideDeadZoneWarning() => 
            _deadZoneWarningUI.SetActive(false);
    }
}