using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Systems
{
    public sealed class PlayErrorClipOnRunSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        private readonly GlitchPhaseService _gpService;
        private readonly SfxConfig _sConfig;
        private readonly TimeService _tService;

        public PlayErrorClipOnRunSystem(GlitchPhaseService gpService, SfxConfig sConfig, TimeService tService)
        {
            _gpService = gpService;
            _sConfig = sConfig;
            _tService = tService;
        }

        public void Run()
        {
            if (!_gpService.Applied || !_tService.Expired(_gpService.LastSoundTime, _gpService.SoundTimeout)) return;

            AudioUtils.CreatePlaySfxRequest(_rAspect, _sConfig.ErrorClip);
        }
    }
}