using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Types;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Systems
{
    public sealed class DespawnSfxAudioSourceByPlayingStatusSystem : IProtoRunSystem
    {
        [DI] private readonly AudioAspect _aAspect;
        private readonly SfxAudioSourcePool _sasPool;

        public DespawnSfxAudioSourceByPlayingStatusSystem(IObjectDomain objDomain)
        {
            objDomain.Get(out _sasPool);
        }

        public void Run()
        {
            foreach (var e in _aAspect.ActiveSfxAudioSources)
            {
                ref var asComponent = ref _aAspect.AudioSourceComponentPool.Get(e);
                if (asComponent.AudioSource.isPlaying) return;
                
                _sasPool.Despawn(asComponent.AudioSource);
            }
        }
    }
}