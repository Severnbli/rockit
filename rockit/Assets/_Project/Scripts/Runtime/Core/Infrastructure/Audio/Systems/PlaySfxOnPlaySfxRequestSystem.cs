using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Types;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Systems
{
    public sealed class PlaySfxOnPlaySfxRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly AudioRequestsAspect _arAspect;
        private readonly SfxAudioSourcePool _sasPool;

        public PlaySfxOnPlaySfxRequestSystem(IObjectDomain objDomain)
        {
            objDomain.Get(out _sasPool);
        }

        public void Run()
        {
            foreach (var reqE in _arAspect.PlaySfxRequests)
            {
                ref var psRequest = ref _arAspect.PlaySfxRequestPool.Get(reqE);
                _sasPool.Spawn(settings: new SfxAudioSourcePoolSpawnSettings { Clip = psRequest.Clip });
            }
        }
    }
}