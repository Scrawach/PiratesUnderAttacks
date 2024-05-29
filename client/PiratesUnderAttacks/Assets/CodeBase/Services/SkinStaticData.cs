using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Services
{
    public class SkinStaticData
    {
        private const string SkinConfigPath = "Configs/Skins/Skins";
        
        private readonly Assets _assets;

        private SkinData _skins;

        public SkinStaticData(Assets assets) => 
            _assets = assets;

        public void Load() => 
            _skins = _assets.Load<SkinData>(SkinConfigPath);

        public Material ForShipSkin(int id)
        {
            if (_skins == null)
                Load();
            
            return _skins.Materials[id];
        }
    }
}