using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Renderer
{
    public class GlitchFeature : ScriptableRendererFeature
    {
        [SerializeField] private Material _material;
        [SerializeField] private GlitchSettings _settings = new();
        [SerializeField] private RenderPassEvent _renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;

        private GlitchFeaturePass _featurePass;

        public GlitchSettings Settings => _settings;

        public override void Create()
        {
            _featurePass = new GlitchFeaturePass(
                _material,
                _settings,
                name
            );

            _featurePass.renderPassEvent = _renderPassEvent;
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            if (_material == null) return;
            
            _featurePass.ConfigureInput(ScriptableRenderPassInput.Color);

            renderer.EnqueuePass(_featurePass);
        }
    }
}