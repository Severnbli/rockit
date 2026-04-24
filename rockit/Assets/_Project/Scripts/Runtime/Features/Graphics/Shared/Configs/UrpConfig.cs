using _Project.Scripts.Modules.Zenject;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Project.Scripts.Runtime.Features.Graphics.Shared.Configs
{
    public class UrpConfig : ScriptableObjectAutoInstaller<UrpConfig>
    {
        [SerializeField] private UniversalRendererData _rendererData;
        
        public UniversalRendererData RendererData => _rendererData;
    }
}