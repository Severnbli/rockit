using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Renderer;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using _Project.Scripts.Runtime.Features.Graphics.Shared.Configs;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Systems
{
    public sealed class LoadGlitchServiceFeatureOnInitSystem : IProtoInitSystem
    {
        private readonly GlitchService _gService;
        private readonly UrpConfig _uConfig;

        public LoadGlitchServiceFeatureOnInitSystem(GlitchService gService, UrpConfig uConfig)
        {
            _gService = gService;
            _uConfig = uConfig;
        }

        public void Init(IProtoSystems systems)
        {
            foreach (var feature in _uConfig.RendererData.rendererFeatures)
            {
                if (feature is not GlitchFeature gFeature) continue;

                _gService.Feature = gFeature;
                return;
            }
        }
    }
}