using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.Effects;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Systems
{
    public sealed class LoadGlitchValuesToGlitchServiceOnInitSystem : IProtoInitSystem
    {
        private readonly GlitchConfig _gConfig;
        private readonly GlitchService _gService;

        public LoadGlitchValuesToGlitchServiceOnInitSystem(GlitchConfig gConfig, GlitchService gService)
        {
            _gConfig = gConfig;
            _gService = gService;
        }

        public void Init(IProtoSystems systems)
        {
            _gService.SetValuesFromSettings(_gConfig.DefaultSettings);
        }
    }
}