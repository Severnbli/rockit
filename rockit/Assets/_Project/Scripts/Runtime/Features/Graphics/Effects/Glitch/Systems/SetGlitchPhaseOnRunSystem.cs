using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using _Project.Scripts.Runtime.Features.Stats.Shared.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.Effects;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Systems
{
    public sealed class SetGlitchPhaseOnRunSystem : IProtoRunSystem
    {
        private readonly GlitchConfig _gConfig;
        private readonly GlitchPhaseService _gpService;
        private readonly GameStatsService _gsService;
        private readonly TimeService _tService;
        private readonly GlitchService _gService;

        public SetGlitchPhaseOnRunSystem(GlitchConfig gConfig, GlitchPhaseService gpService, GameStatsService gsService,
            TimeService tService, GlitchService gService)
        {
            _gConfig = gConfig;
            _gpService = gpService;
            _gsService = gsService;
            _tService = tService;
            _gService = gService;
        }

        public void Run()
        {
            if (_gpService.Applied) return;
            if (!_gConfig.TryGetPhaseByProgressOfPassage01(_gsService.ProgressOfPassage01, out var phase)) return;
            if (!_tService.Expired(_gpService.LastApplyTime, phase.Delay)) return;
            
            _gpService.Applied = true;
            _gpService.StartTime = _tService.UnscaledTime;
            _gpService.Timeout = phase.Timeout;
            _gpService.SoundTimeout = phase.SoundTimeout;
            _gpService.LastSoundTime = _tService.UnscaledTime;
            
            _gService.SetValuesFromSettings(phase.GlitchSettings);
        }
    }
}