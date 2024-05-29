using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Services
{
    [CreateAssetMenu(fileName = "Skins", menuName = "Skins", order = 0)]
    public class SkinData : ScriptableObject
    {
        public List<Material> Materials;
    }
}