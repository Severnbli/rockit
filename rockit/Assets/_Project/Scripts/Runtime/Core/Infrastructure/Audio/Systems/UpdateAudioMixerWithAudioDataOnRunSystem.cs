using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Systems
{
    public sealed class UpdateAudioMixerWithAudioDataOnRunSystem : IProtoRunSystem
    {
        private readonly DataProvider _dProvider;
        private readonly AudioSharedConfig _asConfig;

        public UpdateAudioMixerWithAudioDataOnRunSystem(DataProvider dProvider, AudioSharedConfig asConfig)
        {
            _dProvider = dProvider;
            _asConfig = asConfig;
        }

        public void Run()
        {
            var audioData = _dProvider.AudioData;
            var audioMixer = _asConfig.AudioMixer;

            audioMixer.SetVolumeEnabled(AudioContracts.MasterVolume, audioData.MasterVolumeEnabled);
            audioMixer.SetVolumeEnabled(AudioContracts.MusicVolume, audioData.MusicVolumeEnabled);
            audioMixer.SetVolumeEnabled(AudioContracts.SfxVolume, audioData.SfxVolumeEnabled);
        }
    }
}