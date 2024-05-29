using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Network.Services;
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
            InstallGame(builder);
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
