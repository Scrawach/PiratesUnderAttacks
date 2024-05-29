using CodeBase.Infrastructure.AssetManagement;
using Colyseus;

namespace CodeBase.Network.Services
{
    public class NetworkStaticData
    {
        private const string ServerConfigPath = "Configs/ServerSettings";

        private readonly Assets _assets;
        
        private ColyseusSettings _settings;

        public NetworkStaticData(Assets assets) => 
            _assets = assets;

        public void Load() => 
            _settings = _assets.Load<ColyseusSettings>(ServerConfigPath);

        public ColyseusSettings ForConnection()
        {
            if (_settings == null)
                Load();
            
            return _settings;
        }
    }
}