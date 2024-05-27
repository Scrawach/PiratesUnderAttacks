using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class SkinRenderer : MonoBehaviour
    {
        [SerializeField] private List<Renderer> _skins;

        public void ChangeTo(Material target)
        {
            foreach (var skin in _skins) 
                skin.material = target;
        }
    }
}