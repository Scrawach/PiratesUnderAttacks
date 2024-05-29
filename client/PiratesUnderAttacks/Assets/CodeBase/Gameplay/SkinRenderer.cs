using System.Collections.Generic;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class SkinRenderer : MonoBehaviour
    {
        [SerializeField] private List<Renderer> _skins;
        [SerializeField] private HealthBar _healthBar;

        public Material Current { get; private set; }
        
        public void ChangeTo(Material target)
        {
            Current = target;
            
            foreach (var skin in _skins) 
                skin.material = target;
            
            ChangeHealthBarColor(target.color);
        }

        public void ChangeHealthBarColor(Color target) => 
            _healthBar.ChangeColor(target);
    }
}