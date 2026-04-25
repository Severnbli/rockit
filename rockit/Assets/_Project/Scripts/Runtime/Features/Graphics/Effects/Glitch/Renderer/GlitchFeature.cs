using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Renderer
{
    public class GlitchFeature : ScriptableRendererFeature
    {
        [SerializeField] private Material _material;
        [SerializeField] private GlitchSettings _settings = new ();

        private GlitchFeaturePass _featurePass;
        
        public GlitchSettings Settings => _settings;

        public override void Create()
        {
            _featurePass = new GlitchFeaturePass(
                _material,
                _settings,
                name
            );
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            if (_material == null) return;

            renderer.EnqueuePass(_featurePass);
        }
    }
}