using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Water
{
    public class WaterInteraction : MonoBehaviour
    {
        private static readonly int GlobalEffectRT = Shader.PropertyToID("_GlobalEffectRT");
        private static readonly int ProjectionSize = Shader.PropertyToID("_ProjectionSize");
        private static readonly int Position = Shader.PropertyToID("_Position");
        
        [SerializeField] private RenderTexture _renderTexture;

        private Transform _interactor;

        private void Awake()
        {
            Shader.SetGlobalTexture(GlobalEffectRT, _renderTexture);
            Shader.SetGlobalFloat(ProjectionSize, GetComponent<Camera>().orthographicSize);
        }

        public void AddInteractor(Transform target) => 
            _interactor = target;

        private void Update()
        {
            if (_interactor == null)
                return;
            
            transform.position = new Vector3(_interactor.transform.position.x, transform.position.y, _interactor.transform.position.z);
            Shader.SetGlobalVector(Position, transform.position);
        }
    }
}