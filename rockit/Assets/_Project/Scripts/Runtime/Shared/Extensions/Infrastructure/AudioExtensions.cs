using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared;
using UnityEngine.Audio;

namespace _Project.Scripts.Runtime.Shared.Extensions.Infrastructure
{
    public static class AudioExtensions
    {
        public static void SetVolumeEnabled(this AudioMixer mixer, string paramName, bool enabled)
        {
            mixer.SetFloat(paramName, enabled 
                ? AudioSharedContracts.VolumeEnabled 
                : AudioSharedContracts.VolumeDisabled
            );
        }
    }
}