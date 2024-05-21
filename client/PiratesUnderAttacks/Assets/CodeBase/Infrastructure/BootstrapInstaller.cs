using CodeBase.Infrastructure.AssetManagement;
using Reflex.Core;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class BootstrapInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(Assets));
        }
    }
}
