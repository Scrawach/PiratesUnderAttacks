using CodeBase.Gameplay;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private RatioBar _ratioBar;
        [SerializeField] private TextMeshProUGUI _healthText;

        private void OnEnable() => 
            _health.Changed += OnHealthChanged;

        private void OnDisable() => 
            _health.Changed -= OnHealthChanged;

        private void OnHealthChanged()
        {
            _ratioBar.Fill(_health.Ratio);
            _healthText.text = _health.Current.ToString();
        }

        public void ChangeColor(Color target) => 
            _ratioBar.ChangeColor(target);
    }
}