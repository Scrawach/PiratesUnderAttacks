using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public class Assets
    {
        public TAsset Load<TAsset>(string path) where TAsset : Object => 
            Resources.Load<TAsset>(path);

        public TAsset[] LoadAll<TAsset>(string path) where TAsset : Object =>
            Resources.LoadAll<TAsset>(path);
    }
}