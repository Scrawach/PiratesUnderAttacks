using System.Linq;
using CodeBase.Services;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeBase.UI.Screens
{
    public class LeaderboardScreen : GameScreen
    {
        [SerializeField] private VisualTreeAsset _leaderItemTreeAsset;
        [SerializeField] private int _maxCountOfLeaders = 6;
        
        private VisualElement _leaderboardContainer;
        private LeaderboardService _leaderboardService;
        
        [Inject]
        public void Construct(LeaderboardService leaderboardService) => 
            _leaderboardService = leaderboardService;

        protected override void Awake()
        {
            base.Awake();
            _leaderboardContainer = Screen.Q<VisualElement>("leaderboard-content");
        }

        private void Start() => 
            _leaderboardService.Updated += OnLeaderboardUpdated;

        private void OnDestroy() => 
            _leaderboardService.Updated -= OnLeaderboardUpdated;

        private void OnLeaderboardUpdated()
        {
            _leaderboardContainer.Clear();
            foreach (var leaderInfo in _leaderboardService.GetLeadersSortedByPosition().Take(_maxCountOfLeaders))
            {
                var item = new LeaderboardItem(_leaderItemTreeAsset);
                item.Update(leaderInfo);
                _leaderboardContainer.Add(item);
            }
        }
    }
}