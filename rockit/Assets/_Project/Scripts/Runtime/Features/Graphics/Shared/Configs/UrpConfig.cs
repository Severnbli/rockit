using _Project.Scripts.Modules.Zenject;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Project.Scripts.Runtime.Features.Graphics.Shared.Configs
{
    public sealed class UrpConfig : ScriptableObjectAutoInstaller<UrpConfig>
    {
        [SerializeField] private ScriptableRendererData _rendererData;
        
        public ScriptableRendererData RendererData => _rendererData;
    }
}