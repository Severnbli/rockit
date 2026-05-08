using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio
{
    public sealed class AudioAspect : ProtoAspectInject
    {
        public ProtoPool<AudioSourceComponent> AudioSourceComponentPool;
        public readonly ProtoPool<SfxAudioSourceTag> SfxAudioSourceTagPool;
        public ProtoIt AudioSources = new (It.Inc<AudioSourceComponent>());
        public readonly ProtoIt SfxAudioSources = new (It.Inc<AudioSourceComponent, SfxAudioSourceTag>());
    }
}