using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared
{
    public sealed class AudioSharedAspect : ProtoAspectInject
    {
        public ProtoPool<AudioSourceComponent> AudioSourceComponentPool;
        public ProtoIt AudioSources = new (It.Inc<AudioSourceComponent>());
    }
}