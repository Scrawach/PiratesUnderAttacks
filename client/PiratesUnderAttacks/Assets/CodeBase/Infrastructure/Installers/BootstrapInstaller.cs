using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Network.Services;
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
            InstallGame(builder);
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
        }
    }
}
