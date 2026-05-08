using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Sfx.Tags;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Components;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Sfx
{
    public sealed class SfxAudioAspect : ProtoAspectInject
    {
        public readonly ProtoPool<SfxAudioSourceTag> SfxAudioSourceTagPool;
        public readonly ProtoIt SfxAudioSources = new (It.Inc<AudioSourceComponent, SfxAudioSourceTag>());
    }
}