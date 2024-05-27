using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class SkinInitialize : MonoBehaviour
    {
        [SerializeField] private SkinRenderer _renderer;
        [SerializeField] private Material _skin;
        
        private void Start() => 
            _renderer.ChangeTo(_skin);
    }
}