using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.Effects;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Systems
{
    public sealed class ResetGlitchServiceFeatureOnDestroySystem : IProtoDestroySystem
    {
        private readonly GlitchService _gService;
        private readonly GlitchConfig _gConfig;

        public ResetGlitchServiceFeatureOnDestroySystem(GlitchService gService, GlitchConfig gConfig)
        {
            _gService = gService;
            _gConfig = gConfig;
        }

        public void Destroy()
        {
            _gService.SetValuesFromSettingsToFeature(_gConfig.DefaultSettings);
        }
    }
}