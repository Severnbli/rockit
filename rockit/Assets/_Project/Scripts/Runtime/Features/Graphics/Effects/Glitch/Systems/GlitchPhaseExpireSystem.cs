using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Systems
{
    public sealed class GlitchPhaseExpireSystem : IProtoRunSystem
    {
        private readonly GlitchPhaseService _gpService;
        private readonly TimeService _tService;

        public GlitchPhaseExpireSystem(GlitchPhaseService gpService, TimeService tService)
        {
            _gpService = gpService;
            _tService = tService;
        }

        public void Run()
        {
            if (!_gpService.Applied || !_tService.Expired(_gpService.StartTime, _gpService.Timeout)) return;
            _gpService.Applied = false;
            _gpService.LastApplyTime = _tService.UnscaledTime;
        }
    }
}