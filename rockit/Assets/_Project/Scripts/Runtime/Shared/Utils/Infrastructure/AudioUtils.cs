using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Types;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Shared.Utils.Infrastructure
{
    public static class AudioUtils
    {
        public static ProtoEntity CreatePlaySfxRequest(RequestsAspect aspect, PlaySfxRequest prepared)
        {
            return aspect.CreateRequest(aspect.AudioRequestsAspect.PlaySfxRequestPool, prepared: prepared);
        }

        public static ProtoEntity CreatePlayMusicRequest(RequestsAspect aspect, PlayMusicRequest prepared)
        {
            return aspect.CreateRequest(aspect.AudioRequestsAspect.PlayMusicRequestPool, prepared: prepared);
        }

        public static void SwitchAudioDataVolumeEnabledByAudioGroup(DataProvider dProvider, AudioGroup aGroup)
        {
            var aData = dProvider.AudioData;

            switch (aGroup)
            {
                case AudioGroup.Master:
                {
                    aData.MasterVolumeEnabled = !aData.MasterVolumeEnabled;
                    break;
                }
                case AudioGroup.Music:
                {
                    aData.MusicVolumeEnabled = !aData.MusicVolumeEnabled;
                    break;
                }
                case AudioGroup.Sfx:
                {
                    aData.SfxVolumeEnabled = !aData.SfxVolumeEnabled;
                    break;
                }
            }
        }

        public static bool GetAudioDataVolumeEnabledByAudioGroup(DataProvider dProvider, AudioGroup aGroup)
        {
            var aData = dProvider.AudioData;

            return aGroup switch
            {
                AudioGroup.Master => aData.MasterVolumeEnabled,
                AudioGroup.Music => aData.MusicVolumeEnabled,
                AudioGroup.Sfx => aData.SfxVolumeEnabled,
                _ => false
            };
        }
    }
}