using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using _Project.Scripts.Runtime.Shared.Utils.Infrastructure;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Systems
{
    public sealed class PlayClickClipOnClickedTagSystem : IProtoRunSystem
    {
        [DIRequests] private readonly RequestsAspect _rAspect;
        [DI] private readonly UISharedAspect _usAspect;
        private readonly SfxConfig _sConfig;

        public PlayClickClipOnClickedTagSystem(SfxConfig sConfig)
        {
            _sConfig = sConfig;
        }
        
        public void Run()
        {
            if (_usAspect.ClickedTags.IsEmptySlow()) return;
            
            AudioUtils.CreatePlaySfxRequest(_rAspect, _sConfig.ClickClip);
        }
    }
}