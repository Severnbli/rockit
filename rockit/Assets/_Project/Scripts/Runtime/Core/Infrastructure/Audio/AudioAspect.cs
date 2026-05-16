using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Components;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tags;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Components;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Tags;
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
        public readonly ProtoPool<MasterVolumeTag> MasterVolumeTagPool;
        public readonly ProtoPool<MusicVolumeTag> MusicVolumeTagPool;
        public readonly ProtoIt AudioSources = new (It.Inc<AudioSourceComponent>());
        public readonly ProtoIt SfxAudioSources = new (It.Inc<AudioSourceComponent, SfxAudioSourceTag>());
        public readonly ProtoIt MusicAudioSources = new (It.Inc<AudioSourceComponent, MusicAudioSourceTag>());
        public readonly ProtoIt ActiveAudioSources = new (It.Inc<AudioSourceComponent, ActiveAudioSourceTag>());
        public readonly ProtoIt ActiveMusicAudioSources = new (It.Inc<AudioSourceComponent, ActiveAudioSourceTag, MusicAudioSourceTag>());
        public readonly ProtoIt ActiveSfxAudioSources = new (It.Inc<AudioSourceComponent, ActiveAudioSourceTag, SfxAudioSourceTag>());
        public readonly ProtoIt ClickedMasterVolumes = new (It.Inc<ClickedTag, MasterVolumeTag>());
        public readonly ProtoIt MasterVolumeOpenableClosable = new (It.Inc<MasterVolumeTag, OpenableClosableComponent>());
        public readonly ProtoIt ClickedMusicVolumes = new (It.Inc<ClickedTag, MusicVolumeTag>());
        public readonly ProtoIt OpenableClosableMusicVolumes = new (It.Inc<MusicVolumeTag, OpenableClosableComponent>());
    }
}