using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Network.Services;
using CodeBase.Network.Services.Factory;
using CodeBase.Network.Services.Handlers;
using CodeBase.Network.Services.Ships;
using CodeBase.Services;
using Reflex.Core;
using UnityEngine;

namespace CodeBase.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            InstallAssetManagement(builder);
            InstallNetworkServices(builder);
            InstallMetaServices(builder);
            InstallGameplayServices(builder);
            InstallGame(builder);
        }

        private void InstallGameplayServices(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(ShipRegistry));
            builder.AddSingleton(typeof(ShipFactory));
        }

        private void InstallMetaServices(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(SkinStaticData));
            builder.AddSingleton(typeof(LeaderboardService));
        }

        private static void InstallGame(ContainerBuilder builder) => 
            builder.AddSingleton(typeof(Game));

        private static void InstallAssetManagement(ContainerBuilder builder) => 
            builder.AddSingleton(typeof(Assets));

        private static void InstallNetworkServices(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(NetworkStaticData));
            builder.AddSingleton(typeof(NetworkClient));
            
            builder.AddSingleton(typeof(ShipFactory));
            builder.AddSingleton(typeof(NetworkShipFactory));
            
            builder.AddSingleton(typeof(NetworkStatusProvider), typeof(INetworkRoomHandler), typeof(INetworkStatusProvider));
            
            builder.AddSingleton(typeof(NetworkPlayerInitializer));
            builder.AddSingleton(typeof(NetworkStateInitializer), typeof(INetworkRoomHandler));
        }
    }
}
