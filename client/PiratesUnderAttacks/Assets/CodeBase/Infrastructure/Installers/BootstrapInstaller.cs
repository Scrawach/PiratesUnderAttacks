using CodeBase.Infrastructure.AssetManagement;
using Reflex.Core;
using UnityEngine;

namespace CodeBase.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(Assets));
        }
    }
}
