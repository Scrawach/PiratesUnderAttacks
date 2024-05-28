using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class SkinInitialize : MonoBehaviour
    {
        [SerializeField] private SkinRenderer _renderer;
        [SerializeField] private Material _skin;
        [SerializeField] private Color _healthColor;
        
        private void Start()
        {
            _renderer.ChangeTo(_skin);
            _renderer.ChangeHealthBarColor(_healthColor);
        }
    }
}