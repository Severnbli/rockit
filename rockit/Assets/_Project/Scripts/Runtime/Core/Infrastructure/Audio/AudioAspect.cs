using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tags;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio
{
    public sealed class AudioAspect : ProtoAspectInject
    {
        public readonly ProtoPool<AudioSourceComponent> AudioSourceComponentPool;
        public readonly ProtoPool<SfxAudioSourceTag> SfxAudioSourceTagPool;
        public readonly ProtoPool<MusicAudioSourceTag> MusicAudioSourceTagPool;
        public readonly ProtoPool<ActiveAudioSourceTag> ActiveAudioSourceTagPool;
        public readonly ProtoPool<AudioGroupComponent> AudioGroupComponentPool;
        public readonly ProtoPool<AudioVolumeTag> AudioVolumeTagPool;
        public readonly ProtoIt AudioSources = new (It.Inc<AudioSourceComponent>());
        public readonly ProtoIt SfxAudioSources = new (It.Inc<AudioSourceComponent, SfxAudioSourceTag>());
        public readonly ProtoIt MusicAudioSources = new (It.Inc<AudioSourceComponent, MusicAudioSourceTag>());
        public readonly ProtoIt ActiveAudioSources = new (It.Inc<AudioSourceComponent, ActiveAudioSourceTag>());
        public readonly ProtoIt ActiveMusicAudioSources = new (It.Inc<AudioSourceComponent, ActiveAudioSourceTag, MusicAudioSourceTag>());
        public readonly ProtoIt ActiveSfxAudioSources = new (It.Inc<AudioSourceComponent, ActiveAudioSourceTag, SfxAudioSourceTag>());
    }
}