using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.Effects;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Systems
{
    public class ResetGlitchServiceValuesOnGlitchPhaseNotAppliedSystem : IProtoRunSystem
    {
        private readonly GlitchConfig _gConfig;
        private readonly GlitchPhaseService _gpService;
        private readonly GlitchService _gService;

        public ResetGlitchServiceValuesOnGlitchPhaseNotAppliedSystem(GlitchConfig gConfig, GlitchPhaseService gpService,
            GlitchService gService)
        {
            _gConfig = gConfig;
            _gpService = gpService;
            _gService = gService;
        }

        public void Run()
        {
            if (_gpService.Applied) return;
            
            _gService.SetValuesFromSettings(_gConfig.DefaultSettings);
        }
    }
}