using System.Collections.Generic;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class SkinRenderer : MonoBehaviour
    {
        [SerializeField] private List<Renderer> _skins;
        [SerializeField] private HealthBar _healthBar;

        public void ChangeTo(Material target)
        {
            foreach (var skin in _skins) 
                skin.material = target;
        }

        public void ChangeHealthBarColor(Color target) => 
            _healthBar.ChangeColor(target);
    }
}